using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        dir = ((PlayerWeapon.instance.transform.position + Quaternion.Euler(0, 0, Random.Range(-Accuracy / 2f, Accuracy / 2f)) * PlayerWeapon.instance.transform.up) - PlayerWeapon.instance.transform.position).normalized;
        vel = dir * speed;
    }

    private void OnDrawGizmos()
    {
        
    }
}
