using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState State;

    public static event Action<GameState> OnGameStateChanged;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        UpdateGameState(GameState.Mainmenu);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateGameState(string newState)
    {
        UpdateGameState((GameState)System.Enum.Parse(typeof(GameState), newState));
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (State)
        {
            case GameState.Mainmenu:
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
                HandleCombatState();
                break;
            case GameState.BossFight:
                break;
            case GameState.Upgrade:
                HandleUpgradeState();
                break;
            case GameState.Victory:
                HandleVicotyState();
                break;
            case GameState.Defeat:
                HandleDefeatState();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }

    public async void HandleCombatState()
    {
        //Expand Arena
        Edge.SetRadius(20f, 2f);

        CameraManager.Dive();

        while(CameraManager.CheckDive())
        {
            Debug.Log("Is Diving");
            await Task.Yield();
        }

        //Start Wave
        EntityManager.instance.SpawnWave();
    }

    public async void HandleBassFightState()
    {
        //Expand Arena
        Edge.SetRadius(25f, 2f);

        CameraManager.Dive();

        if (CameraManager.CheckDive())
        {
            await Task.Yield();
        }

        //Start Wave
        EntityManager.instance.SpawnWave();
    }

    public void HandleUpgradeState()
    {
        //Pause Enemy Spawn
        EntityManager.instance.StopSpawn();

        //Kill all current enemies
        Collider2D[] colliders = Physics2D.OverlapCircleAll(Vector2.zero, Edge.radius * 2f, LayerMask.GetMask("Enemy"));
        foreach (Collider2D c in colliders)
        {
            c.gameObject.GetComponent<Enemy>().Kill();
        }

        //Change Background Color
        CameraManager.ChangeColor(Color.black);

        //Update level
        LevelManager.NextSubLevel();

        //Update charge panel
        ChargePanel.instance.ResetBar();
    }

    public void HandleVicotyState()
    {
        //Change Background Color
        CameraManager.ChangeColor(Color.HSVToRGB(0.5f, 0.5f, 1f));
    }

    public void HandleDefeatState()
    {
        //Change Background Color
        CameraManager.ChangeColor(Color.HSVToRGB(0f, 0f, 0.3f));
    }

    public void Exit()
    {
        Application.Quit();
    }
}
