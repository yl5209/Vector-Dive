using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public WaveType type;
    public GameObject enemy;
    public float time;
    public int number;
    public float radius;
}

[System.Serializable]
public class SubLevel
{
    public List<Wave> waves;
    public int charge;
}

[CreateAssetMenu(fileName = "New Level", menuName = "Level")]
[System.Serializable]
public class Level : ScriptableObject
{
    public string Name;
    public List<SubLevel> subLevels;
}
