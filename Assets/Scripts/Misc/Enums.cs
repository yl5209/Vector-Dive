using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

public enum GameState
{
    Mainmenu,
    Combat,
    Upgrade,
    Victory,
    Defeat
}