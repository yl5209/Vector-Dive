using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : Vehicle
{
    public int Dmg { get; set; }
    public DmgType Dmg_type { get; set; }
    public float Life { get; set; }
    public float Life_count { get; set; }
    public EntityType Type { get; set; }
    public float Force { get; set; }

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

    public void Hit()
    {
        Life_count -= 1;

        if(Life_count < 0)
        {
            Destroy(gameObject);
        }
    }
}
