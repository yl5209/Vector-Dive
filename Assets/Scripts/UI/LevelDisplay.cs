using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelDisplay : MonoBehaviour
{
    public GameObject display;
    private TextMeshProUGUI tmp;
    // Start is called before the first frame update
    void Start()
    {
        tmp = display.GetComponentInChildren<TextMeshProUGUI>();
        UpdateLevelName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLevelName()
    {
        tmp.text = LevelManager.current_level.Name;
    }
}
