using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName  = "New Weapon", menuName = "Weapon")]
public class WeaponData : ScriptableObject
{
    public int id; //Weapon ID used to identify weapon data

    public int dmg; //The amount of dmg each bullet deals
    public DmgType dmg_type; //Target filter

    public float fire_rate; //Attack per second
    public int multi_shot; //Number of bullet of each attack

    public float bullet_speed; //Speed of bullets
    public float bullet_speed_offet; //Min and max offset of each bullet
    public float bullet_life; //Life span of each bullet in seconds
    public float bullet_force; //Magnitude of force applied to target

    public int pierce; //Number of enemy each bullet could hit
    public int burst; //Number of bullet of each burst, 0 mean not a burst weapon
    public int burst_rate; //Fire rate during burst

    public float accuracy; //Weapon Accuracy, 100 is max

    public float charge_time; //Time need to charge up
    public float charge_speed; //Charge speed multiplier
    public float charge_fall_speed; //Charge fall speed multiplier

    public GameObject bullet;

    public bool equal_division;
}
