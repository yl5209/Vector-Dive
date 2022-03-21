using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName  = "New Weapon", menuName = "Weapon")]
public class WeaponData : ScriptableObject
{
    public int dmg;

    public float fire_rate;
    public float multi_shot;

    public float bullet_speed;
    public float bullet_life;

    public float accuracy;

    public float charge_time;
    public float charge_speed;
    public float charge_fall_speed;

    public GameObject bullet;
}
