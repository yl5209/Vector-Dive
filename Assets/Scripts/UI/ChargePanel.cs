using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
using TMPro;

public class ChargePanel : MonoBehaviour
{
    public static ChargePanel instance;

    public int charge_max = 100;
    public int charge_current = 0;
    [Range(0.1f, 1f)]
    public float speed;
    public float blink_speed;

    public GameObject fill;

    private float max_width;
    private float current_width;
    private float vel;

    private Tween hint_blink;
    private TextMeshProUGUI space_gui;

    public static event Action FullCharge;

    public bool IsFullCharge { get { return charge_current == charge_max; } }

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        max_width = fill.GetComponent<RectTransform>().sizeDelta.x;
        space_gui = GetComponentInChildren<TextMeshProUGUI>();
        hint_blink = space_gui.DOColor(new Color(1.0f, 1.0f, 1.0f, 1.0f), blink_speed).SetLoops(-1, LoopType.Yoyo).Pause();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBar();
    }

    private void UpdateBar()
    {
        current_width = Mathf.SmoothDamp(current_width, ((float)charge_current / (float)charge_max) * max_width, ref vel, speed);
        fill.GetComponent<RectTransform>().sizeDelta = new Vector2(current_width, fill.GetComponent<RectTransform>().sizeDelta.y);
    }

    public void AddCharge(int num)
    {
        charge_current += num;

        if (charge_current >= charge_max)
        {
            charge_current = charge_max;
            if (!hint_blink.IsPlaying())
                hint_blink.Restart();
            FullCharge?.Invoke();
        }
    }

    public void ResetBar()
    {
        DOVirtual.Int(charge_current, 0, 3f, (x) => { charge_current = x; });
        charge_max = LevelManager.current_sublevel.charge;
        hint_blink.Goto(0f);
    }
}
