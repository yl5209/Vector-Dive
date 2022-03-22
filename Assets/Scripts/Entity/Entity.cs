using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

public abstract class Entity : MonoBehaviour
{
    public int hp;
    public int def;
    public EntityType type;

    public virtual void ApplyDamage(int _dmg)
    {
        hp -= _dmg;

        if (hp <= 0)
        {
            Death();
        }
    }

    public virtual void Death()
    {
        Destroy(gameObject);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            Bullet b = collision.transform.gameObject.GetComponent<Bullet>();
            if (b.Dmg_type == DmgType.All)
            {
                ApplyDamage(b.Dmg);
                GetComponent<Vehicle>().ApplyForceRb(b.dir * b.Force);
            }
            else
            {
                if (b.Type != type)
                {
                    ApplyDamage(b.Dmg);
                    GetComponent<Vehicle>().ApplyForceRb(b.dir * b.Force);
                }
            }
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            Bullet b = collision.transform.gameObject.GetComponent<Bullet>();
            Debug.Log(b.dir * b.Force);
            if (b.Dmg_type == DmgType.All)
            {
                ApplyDamage(b.Dmg);
                GetComponent<Vehicle>().ApplyForceRb(b.dir * b.Force);
            }
            else
            {
                if (b.Type != type)
                {
                    ApplyDamage(b.Dmg);
                    GetComponent<Vehicle>().ApplyForceRb(b.dir * b.Force);
                }
            }
        }
    }
}
