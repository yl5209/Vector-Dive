using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum EntityType
{
    Player,
    Enemy
}

public enum DmgType
{
    Opposite,
    All,
    None
}

[SerializeField]
public enum GameState
{
    Mainmenu,
    Combat,
    BossFight,
    Upgrade,
    Victory,
    Defeat
}

public enum WaveType
{
    Group,
    Random,
    Point,
    Boss
}