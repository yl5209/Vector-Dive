using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wwise_StateController : MonoBehaviour
{
    private void Awake()
    {
        GameManager.OnGameStateChanged += WwiseStateOnGameStateChanged;
        //AkSoundEngine.RegisterGameObj(gameObject);
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= WwiseStateOnGameStateChanged;
    }

    private void WwiseStateOnGameStateChanged(GameState state)
    {
        uint state_id;

        switch (state)
        {
            case GameState.Mainmenu:
                if (AkSoundEngine.GetState("GameState", out state_id) == AKRESULT.AK_Success)
                    if (state_id != 2607556080U)
                        AkSoundEngine.PostEvent("Set_State_Menu", gameObject);
                break;
            case GameState.Option:
                break;
            case GameState.Tutorial:
                break;
            case GameState.ModeSelection:
                break;
            case GameState.TrackSelection:
                break;
            case GameState.Combat:
                break;
            case GameState.BossFight:
                break;
            case GameState.Upgrade:
                break;
            case GameState.Victory:
                break;
            case GameState.Defeat:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }

    }
}
