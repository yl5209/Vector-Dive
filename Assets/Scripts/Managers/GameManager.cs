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

    public void Init()
    {
        UpdateGameState(GameState.Mainmenu);
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
                HandleMainmenuState();
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

        Debug.Log(LevelManager.current_level_index + " " + LevelManager.current_sublevel_index + " " + LevelManager.current_wave_index);

        OnGameStateChanged?.Invoke(newState);
    }

    public void HandleMainmenuState()
    {
        LevelManager.ResetLevelManager();
    }

    public async void HandleCombatState()
    {
        //Expand Arena
        Edge.SetRadius(20f, 2f);

        CameraManager.Dive();

        //Update charge panel
        ChargePanel.instance.ResetBar();

        while (CameraManager.CheckDive())
        {
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
        if (colliders.Length > 0)
        {
            foreach (Collider2D c in colliders)
            {
                Enemy enemy;
                EnemySpawner enemySpawner;
                if (c.gameObject.TryGetComponent(out enemy))
                    c.gameObject.GetComponent<Enemy>().Kill();
                if (c.gameObject.TryGetComponent(out enemySpawner))
                    c.gameObject.GetComponent<EnemySpawner>().Kill();
            }
        }

        //Change Background Color
        CameraManager.ChangeColor(new Color(0.2f, 0.2f, 0.2f));

        //Update level
        LevelManager.NextSubLevel();
    }

    public void HandleVicotyState()
    {
        //Change Background Color
        CameraManager.ChangeColor(Color.HSVToRGB(0.15f, 0.6f, 0.6f));

        //Kill all current enemies
        Collider2D[] colliders = Physics2D.OverlapCircleAll(Vector2.zero, Edge.radius * 2f, LayerMask.GetMask("Enemy"));
        if (colliders.Length > 0)
        {
            foreach (Collider2D c in colliders)
            {
                Enemy enemy;
                EnemySpawner enemySpawner;
                if (c.gameObject.TryGetComponent(out enemy))
                    c.gameObject.GetComponent<Enemy>().Kill();
                if (c.gameObject.TryGetComponent(out enemySpawner))
                    c.gameObject.GetComponent<EnemySpawner>().Kill();
            }
        }
    }

    public void HandleDefeatState()
    {
        //Change Background Color
        CameraManager.ChangeColor(Color.HSVToRGB(0f, 0f, 0.3f));

        //Kill all current enemies
        Collider2D[] colliders = Physics2D.OverlapCircleAll(Vector2.zero, Edge.radius * 2f, LayerMask.GetMask("Enemy"));
        if (colliders.Length > 0)
        {
            foreach (Collider2D c in colliders)
            {
                Enemy enemy;
                EnemySpawner enemySpawner;
                if (c.gameObject.TryGetComponent(out enemy))
                    c.gameObject.GetComponent<Enemy>().Kill();
                if (c.gameObject.TryGetComponent(out enemySpawner))
                    c.gameObject.GetComponent<EnemySpawner>().Kill();
            }
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
