using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public List<ParticleSystem> particles;
    public bool playOnStart = true;
    public bool destoryOnEnd = true;

    public float end_time;

    public void Play()
    {
        foreach (ParticleSystem p in particles)
        {
            p.Play();
        }
    }

    private void Start()
    {
        if (playOnStart)
            Play();

        end_time = particles[0].main.duration + Time.time;
        Debug.Log(particles[0].main.duration);
    }

    private void Update()
    {
        if(Time.time > end_time)
        {
            Destroy(gameObject);
        }
    }
}
