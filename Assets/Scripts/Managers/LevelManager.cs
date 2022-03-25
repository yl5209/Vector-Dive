using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instacne;
    public static Level current_level;
    public static SubLevel current_sublevel;

    public static event Action OnWaveClear;
    public static int current_level_index = 0;

    public static void LoadLevel(Level level)
    {
        current_level = level;
        current_sublevel = level.subLevels[0];
    }

    public static void StartLevel()
    {
        EntityManager.instance.SpawnWave();
    }

    public static void Clear()
    {
        current_level = null;
    }

    private void Start()
    {
        LoadLevel(LevelDatabase.instance.levels[current_level_index]);
    }

    private void Update()
    {
        if(current_level != null)
        {

        }
    }

    public void UpdateLevel()
    {

    }

    public static void MoveSelection(int i)
    {
        current_level_index += i;

        if(current_level_index >= LevelDatabase.instance.levels.Count)
        {
            current_level_index -= LevelDatabase.instance.levels.Count;
        }
        else if(current_level_index < 0)
        {
            current_level_index += LevelDatabase.instance.levels.Count;
        }

        current_level = LevelDatabase.instance.levels[current_level_index];
    }
}
