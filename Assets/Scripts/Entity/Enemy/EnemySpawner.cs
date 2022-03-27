using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float timer;
    public GameObject prefab;

    ParticleController particleController;
    // Start is called before the first frame update
    void Start()
    {
        particleController = GetComponentInChildren<ParticleController>();
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator Spawn()
    {
        particleController.Play();

        float end = Time.time + timer;

        while (Time.time < end)
        {
            yield return null;
        }

        Instantiate(prefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public async void Spawn(GameObject enemy)
    {
        particleController.Play();

        float end = Time.time + timer;

        while (Time.time < end)
        {
            await Task.Yield();
        }

        Instantiate(enemy, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }

    public void Kill()
    {
        EntityManager.EnemyDeath();
        StopAllCoroutines();
        Destroy(gameObject);
    }
}
