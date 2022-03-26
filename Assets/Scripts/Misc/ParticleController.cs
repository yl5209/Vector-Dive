using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public List<ParticleSystem> particles;
    public bool playOnStart = true;
    //public bool destoryOnEnd = true;

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
    }

    private void Update()
    {
    }
}
