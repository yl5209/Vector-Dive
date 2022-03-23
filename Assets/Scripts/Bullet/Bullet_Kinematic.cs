using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class Bullet_Kinematic : Bullet
{
    protected override void Start()
    {
        base.Start();
        CalculateVelocity();
        rb.velocity = vel;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void CalculateVelocity()
    {
        vel = dir * speed;
    }

    private void OnDrawGizmos()
    {
        
    }
}
