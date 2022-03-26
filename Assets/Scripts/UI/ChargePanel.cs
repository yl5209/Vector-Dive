using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class ChargePanel : MonoBehaviour
{
    public static ChargePanel instance;

    public int charge_max = 100;
    public int charge_current = 0;
    public float speed;

    public GameObject fill;

    private float max_width;
    private float current_width;
    private float vel;

    public static event Action FullCharge;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        max_width = fill.GetComponent<RectTransform>().sizeDelta.x;
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
            FullCharge?.Invoke();
        }
    }

    public void ResetBar()
    {
        DOVirtual.Int(charge_current, 0, 3f, (x) => { charge_current = x; });
        charge_max = LevelManager.current_sublevel.charge;
    }
}
