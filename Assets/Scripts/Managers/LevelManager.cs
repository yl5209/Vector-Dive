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

    public static int current_level_index = 0;
    public static int current_sublevel_index = 0;
    public static int current_wave_index = 0;

    public static void LoadLevel(Level level)
    {
        current_sublevel_index = 0;
        current_wave_index = 0;

        current_level = level;
        current_sublevel = level.subLevels[current_sublevel_index];
    }

    public static void StartLevel()
    {
        EntityManager.instance.SpawnWave();
    }

    public static bool IsLastWave()
    {
        return current_sublevel_index == current_level.subLevels.Count - 1;
    }

    public static SubLevel NextSubLevel()
    {
        current_sublevel_index++;
        if (current_sublevel_index >= current_level.subLevels.Count)
        {
            GameManager.instance.UpdateGameState(GameState.Victory);
            ResetLevelManager();
        }

        return current_level.subLevels[current_sublevel_index];
    }

    public static Wave NextWave()
    {
        current_wave_index++;
        if (current_wave_index >= current_sublevel.waves.Count)
            current_wave_index = 0;

        return current_sublevel.waves[current_wave_index];
    }

    public static void Clear()
    {
        current_level = null;
    }

    public static void ResetLevelManager()
    {
        current_level_index = 0;
        current_sublevel_index = 0;
        current_wave_index = 0;
        LoadLevel(LevelDatabase.instance.levels[current_level_index]);
    }

    private void Start()
    {
        LoadLevel(LevelDatabase.instance.levels[current_level_index]);
    }

    private void Update()
    {
        if (current_level != null)
        {

        }
    }

    public static void MoveSelection(int i)
    {
        current_level_index += i;

        if (current_level_index >= LevelDatabase.instance.levels.Count)
        {
            current_level_index -= LevelDatabase.instance.levels.Count;
        }
        else if (current_level_index < 0)
        {
            current_level_index += LevelDatabase.instance.levels.Count;
        }

        current_level = LevelDatabase.instance.levels[current_level_index];
    }
}
