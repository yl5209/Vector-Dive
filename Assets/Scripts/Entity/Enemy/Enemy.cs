using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    public override void ApplyDamage(int _dmg)
    {
        base.ApplyDamage(_dmg);
        GetComponentInChildren<SpriteGlow>().Glow();
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
