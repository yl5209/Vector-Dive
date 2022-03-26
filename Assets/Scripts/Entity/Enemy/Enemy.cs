using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : Entity
{
    public int dive_point = 1;

    void Start()
    {

    }

    void Update()
    {

    }

    public override void ApplyDamage(int _dmg)
    {
        GetComponentInChildren<SpriteGlow>().Glow();
        base.ApplyDamage(_dmg);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            Bullet b = collision.transform.gameObject.GetComponent<Bullet>();
            if (b.Dmg_type == DmgType.All)
            {
                b.Hit();
                ApplyDamage(b.Dmg);
                GetComponent<Vehicle>().ApplyForceRb(b.dir * b.Force);
            }
            else
            {
                if (b.Type != type)
                {
                    b.Hit();
                    ApplyDamage(b.Dmg);
                    GetComponent<Vehicle>().ApplyForceRb(b.dir * b.Force);
                }
            }
        }
    }

    public override void Death()
    {
        ChargePanel.instance.AddCharge(dive_point);
        EntityManager.EnemyDeath();
        base.Death();
    }

    public void Kill()
    {
        EntityManager.EnemyDeath();
        base.Death();
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.transform.tag == "Bullet")
    //    {
    //        Bullet b = collision.transform.gameObject.GetComponent<Bullet>();
    //        if (b.Dmg_type == DmgType.All)
    //        {
    //            b.Hit();
    //            ApplyDamage(b.Dmg);
    //            GetComponent<Vehicle>().ApplyForceRb(b.dir * b.Force);
    //        }
    //        else
    //        {
    //            if (b.Type != type)
    //            {
    //                b.Hit();
    //                ApplyDamage(b.Dmg);
    //                GetComponent<Vehicle>().ApplyForceRb(b.dir * b.Force);
    //            }
    //        }
    //    }
    //}
}
