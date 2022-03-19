using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private float frequency = 0.01f;
    private float amplitude = 1f;
    private float sample_time;
    private float[] spectrum = new float[512];
    private AudioClip clip;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        clip = GetComponent<AudioSource>().clip;
        sample_time = Time.time + frequency;
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > sample_time)
        {
            AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Triangle);
            sample_time = Time.time + frequency;
        }

        //for (int i = 1; i < spectrum.Length - 1; i++)
        //{
        //    Debug.DrawLine(new Vector3(i - 1, spectrum[i] * amplitude + 10, 0), new Vector3(i, spectrum[i + 1] * amplitude + 10, 0), Color.red);
        //    Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
        //    Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
        //    Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.blue);
        //}

        if (Input.GetKeyDown(KeyCode.Q))
        {
            for(int i = 0; i < spectrum.Length; i++)
            {
                Debug.Log(spectrum[i]);
            }
        }
    }

    public float[] GetSamples()
    {
        return spectrum;
    }

    public float GetMax()
    {
        return spectrum.Max();
    }
}
