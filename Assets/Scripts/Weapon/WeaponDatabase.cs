using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDatabase : MonoBehaviour
{
    public static WeaponDatabase instance;

    public List<WeaponData> weapons;

    private void Awake()
    {
        instance = this;
    }
}
