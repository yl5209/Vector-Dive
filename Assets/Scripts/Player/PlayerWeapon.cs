using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    public static PlayerWeapon instance;
    public static List<Weapon> weapons;

    private void Awake()
    {
        instance = this;
        weapons = new List<Weapon>();
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    private void GameManagerOnGameStateChanged(GameState state)
    {
        ControlWeaponState(state == GameState.Combat);
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

    public static void ControlWeaponState(bool state)
    {
        foreach (Weapon w in weapons)
        {
            if (state)
            {
                w.enabled = true;
            }
            else
            {
                w.enabled = false;
            }
        }
    }
}
