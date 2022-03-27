using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDive : MonoBehaviour
{
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
                GameManager.instance.UpdateGameState(GameState.Victory);
            }
            else
            {
                GameManager.instance.UpdateGameState(GameState.Upgrade);
            }
        }

    }
}
