using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instacne;
    public static Level current_level;

    public static event Action OnWaveClear;

    public static void LoadLevel(Level level)
    {
        current_level = level;
    }

    public static void Clear()
    {
        current_level = null;
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
}
