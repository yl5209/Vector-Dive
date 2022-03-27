using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDive : MonoBehaviour
{
    public GameObject levelwipe_vfx;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInput.instance.Dive)
        {
            Dive();
        }
    }

    void Dive()
    {
        if (ChargePanel.instance.IsFullCharge && GameManager.instance.State == GameState.Combat)
        {
            if (LevelManager.IsLastWave())
            {
                PlayVFX();
                GameManager.instance.UpdateGameState(GameState.Victory);
            }
            else
            {
                PlayVFX();
                GameManager.instance.UpdateGameState(GameState.Upgrade);
            }
        }

    }

    public void PlayVFX()
    {
        Instantiate(levelwipe_vfx, transform.position, Quaternion.identity);
    }
}
