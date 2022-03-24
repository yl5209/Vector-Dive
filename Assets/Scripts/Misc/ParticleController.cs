using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public List<ParticleSystem> particles;

    public void Play()
    {
        foreach (ParticleSystem p in particles)
        {
            p.Play();
        }
    }
}
