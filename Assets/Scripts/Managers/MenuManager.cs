using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _MainmenuPanel, _UpgradePanel, _ChargePanel, _OptionPanel, _TutorialPanel, _ModePanel;

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    private void GameManagerOnGameStateChanged(GameState state)
    {
        _MainmenuPanel.SetActive(state == GameState.Mainmenu);
        _OptionPanel.SetActive(state == GameState.Option);
        _TutorialPanel.SetActive(state == GameState.Tutorial);
        _ModePanel.SetActive(state == GameState.ModeSelection);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
