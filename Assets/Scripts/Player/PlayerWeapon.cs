using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public static PlayerWeapon instance;
    public List<Weapon> weapons;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        weapons.Add(GetComponent<Weapon>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
