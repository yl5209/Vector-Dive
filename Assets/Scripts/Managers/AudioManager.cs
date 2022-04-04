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
        //clip = GetComponent<AudioSource>().clip;
        //sample_time = Time.time + frequency;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Time.time > sample_time)
        //{
        //    AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Triangle);
        //    sample_time = Time.time + frequency;
        //}
    }

    public void SetMasterVolume(float v)
    {
        //GetComponent<AudioSource>().volume = v;
        AkSoundEngine.SetRTPCValue("MasterVolume", v * 100f);
    }
    public void SetMusicVolume(float v)
    {
        AkSoundEngine.SetRTPCValue("MusicVolume", v * 100f);
    }
    public void SetSoundVolume(float v)
    {
        AkSoundEngine.SetRTPCValue("SFXVolume", v * 100f);
    }

    public void SetLowPass(float v)
    {
        AkSoundEngine.SetRTPCValue("Global_LowPass", v * 60f);
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
