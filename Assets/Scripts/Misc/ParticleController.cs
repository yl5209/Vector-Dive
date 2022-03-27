using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public List<ParticleSystem> particles;
    public bool playOnStart = true;
    public bool destoryOnEnd = true;
    public bool loop = false;

    private float end_time;

    public void Play()
    {
        foreach (ParticleSystem p in particles)
        {
            if (loop)
            {
                ParticleSystem.MainModule main = p.main;
                main.loop = true;
            }

            p.Play();
        }
    }

    private void Start()
    {
        if (playOnStart)
            Play();

        end_time = particles[0].main.duration + Time.time;
    }

    private void Update()
    {
        if (destoryOnEnd)
        {
            if (Time.time > end_time)
            {
                Destroy(gameObject);
            }
        }
    }
}
