using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class EntityManager : MonoBehaviour
{
    public static EntityManager instance;

    public static event Action OnEnemyDeath;
    public static event Action OnEnemySpawn;
    public static event Action WaveClear;
    public static event Action OnWaveTimeEnd;

    //public int max_enemies;
    public int active_enemies;

    public float spawn_time;
    public float group_radius;

    public GameObject spawner_prefab;

    private Vector3 group_spawn_point;
    private bool isSpawning, spawn_flag;
    private float spawn_timer;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //max_enemies = 0;
        active_enemies = 0;

        OnEnemySpawn += () => { active_enemies++; };
        OnEnemyDeath += () => { 
            active_enemies--;
            if (!isSpawning)
                WaveClear?.Invoke();
        };

        WaveClear += SpawnWave;
        OnWaveTimeEnd += SpawnWave;
    }

    private void Update()
    {
        if(Time.time > spawn_timer && spawn_flag)
        {
            spawn_flag = !spawn_flag;
            OnWaveTimeEnd?.Invoke();
        }
    }

    public void StopSpawn()
    {
        StopAllCoroutines();
    }

    public void SpawnWave()
    {
        StartCoroutine(SpawnWave(LevelManager.current_sublevel.GetCurrentWave()));
    }

    public IEnumerator SpawnWave(Wave wave)
    {
        int num = 0;
        GameObject obj;

        group_spawn_point = new Vector3(UnityEngine.Random.Range(-Edge.radius, Edge.radius), UnityEngine.Random.Range(-Edge.radius, Edge.radius), 0);
        isSpawning = true;
        spawn_timer = Time.time + wave.time;
        spawn_flag = true;

        while (num < wave.number)
        {
            var end = Time.time + spawn_time;

            while(Time.time < end)
            {
                yield return null;
            }

            obj = Instantiate(spawner_prefab, CalculateSpawnPosition(wave.type), Quaternion.identity);
            obj.GetComponent<EnemySpawner>().prefab = wave.enemy;

            yield return null;
        }

        isSpawning = false;
    }

    public Vector3 CalculateSpawnPosition(WaveType type)
    {
        Vector3 pos = Vector3.zero;

        switch (type)
        {
            case WaveType.Group:
                pos = new Vector3(group_spawn_point.x + UnityEngine.Random.Range(-group_radius, group_radius), group_spawn_point.y + UnityEngine.Random.Range(-group_radius, group_radius), 0);
                break;
            case WaveType.Random:
                pos = new Vector3(UnityEngine.Random.Range(-Edge.radius, Edge.radius), UnityEngine.Random.Range(-Edge.radius, Edge.radius), 0);
                break;
        }

        return pos;
    }
}
