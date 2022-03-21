using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : Vehicle
{
    public int Dmg { get; set; }
    public float Accuracy { get; set; }
    public float Life { get; set; }

    private float life_end;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        life_end = Time.time + Life;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if(Time.time > life_end)
        {
            Destroy(gameObject);
        }
    }
}
