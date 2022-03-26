using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class EntityManager : MonoBehaviour
{
    public static EntityManager instance;

    public static event Action OnEnemyDeath;
    public static void EnemyDeath()
    {
        Debug.Log("Enemy Death");
        OnEnemyDeath?.Invoke();
    }
    public static event Action OnEnemySpawn;
    public static void EnemySpawn()
    {
        Debug.Log("Enemy Spawn");
        OnEnemySpawn?.Invoke();
    }
    public static event Action OnWaveClear;
    public static void WaveClear()
    {
        Debug.Log("Wave Clear");
        OnWaveClear?.Invoke();
    }
    public static event Action OnWaveTimeEnd;

    public static void WaveTimeEnd()
    {
        Debug.Log("Wave Time End");
        OnWaveTimeEnd?.Invoke();
    }

    //public int max_enemies;
    public int active_enemies;

    public float spawn_time;
    public float group_radius;

    public GameObject spawner_prefab;

    private Vector3 group_spawn_point;
    private bool isSpawning, spawn_flag;
    private float spawn_timer;
    private int overlap_check = 10;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //max_enemies = 0;
        active_enemies = 0;

        OnEnemySpawn += () => { active_enemies++; };
        OnEnemyDeath += () =>
        {
            active_enemies--;
            Debug.Log("Enemy Died");
            if (!isSpawning && active_enemies <= 0)
                WaveClear();
        };

        OnWaveClear += SpawnWave;
        OnWaveTimeEnd += SpawnWave;
    }

    private void Update()
    {
        if (Time.time > spawn_timer && spawn_flag)
        {
            spawn_flag = !spawn_flag;
            WaveTimeEnd();
        }
    }

    public void StopSpawn()
    {
        StopAllCoroutines();
    }

    public void SpawnWave()
    {
        SpawnWave(LevelManager.GetNextWave());
    }

    public void SpawnWave(Wave wave)
    {
        switch (wave.type)
        {
            case WaveType.Group:
                StartCoroutine(HandleGroupWave(wave));
                break;
            case WaveType.Random:
                StartCoroutine(HandleRandomWave(wave));
                break;
            case WaveType.Point:
                break;
            case WaveType.Boss:
                HandleBossWave(wave);
                break;
        }
    }

    public IEnumerator HandleGroupWave(Wave wave)
    {
        int num = 0;
        GameObject obj;

        group_spawn_point = CalculateGroupSpawnPosition();
        isSpawning = true;
        spawn_timer = Time.time + wave.time;
        spawn_flag = true;

        var end = Time.time + spawn_time;

        while (num < wave.number)
        {
            end = Time.time + spawn_time;

            if (Time.time < end)
            {
                yield return null;
            }

            Vector3 pos = new Vector3(group_spawn_point.x + UnityEngine.Random.Range(-group_radius, group_radius), group_spawn_point.y + UnityEngine.Random.Range(-group_radius, group_radius), 0);
            for (int i = 0; i < overlap_check; i++)
            {
                if (Physics2D.OverlapCircle(pos, 1f, LayerMask.GetMask("Enemy")) != null)
                {
                    pos = new Vector3(group_spawn_point.x + UnityEngine.Random.Range(-group_radius, group_radius), group_spawn_point.y + UnityEngine.Random.Range(-group_radius, group_radius), 0);
                }
            }

            obj = Instantiate(spawner_prefab, pos, Quaternion.identity);
            obj.GetComponent<EnemySpawner>().prefab = wave.enemy;
            EnemySpawn();
            num++;

            yield return null;
        }

        isSpawning = false;
    }

    public IEnumerator HandleRandomWave(Wave wave)
    {
        int num = 0;
        GameObject obj;

        isSpawning = true;
        spawn_timer = Time.time + wave.time;
        spawn_flag = true;

        while (num < wave.number)
        {
            var end = Time.time + spawn_time;

            if (Time.time < end)
            {
                yield return null;
            }

            Vector3 pos = new Vector3(UnityEngine.Random.Range(-Edge.radius, Edge.radius), UnityEngine.Random.Range(-Edge.radius, Edge.radius), 0);
            for (int i = 0; i < overlap_check; i++)
            {
                if (Physics2D.OverlapCircle(pos, 1f, LayerMask.GetMask("Enemy")) != null)
                {
                    pos = new Vector3(UnityEngine.Random.Range(-Edge.radius, Edge.radius), UnityEngine.Random.Range(-Edge.radius, Edge.radius), 0);
                }
            }

            obj = Instantiate(spawner_prefab, pos, Quaternion.identity);
            obj.GetComponent<EnemySpawner>().prefab = wave.enemy;
            EnemySpawn();
            num++;

            yield return null;
        }

        isSpawning = false;
    }

    public void HandleBossWave(Wave wave)
    {
        GameObject obj;
        obj = Instantiate(spawner_prefab, Vector3.zero, Quaternion.identity);
        obj.GetComponent<EnemySpawner>().prefab = wave.enemy;
    }

    public Vector3 CalculateGroupSpawnPosition()
    {
        Vector3 vector3 = new Vector3(UnityEngine.Random.Range(-Edge.radius, Edge.radius), UnityEngine.Random.Range(-Edge.radius, Edge.radius), 0);

        while (Physics2D.OverlapCircle(vector3, 3f, LayerMask.GetMask("Enemy")) != null)
        {
            vector3 = new Vector3(UnityEngine.Random.Range(-Edge.radius, Edge.radius), UnityEngine.Random.Range(-Edge.radius, Edge.radius), 0);
        }

        return vector3;
    }
}
