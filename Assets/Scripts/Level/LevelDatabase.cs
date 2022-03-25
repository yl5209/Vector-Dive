using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelDatabase : MonoBehaviour
{
    public static LevelDatabase instance;

    public List<Level> levels;

    private void Awake()
    {
        instance = this;
    }
}
