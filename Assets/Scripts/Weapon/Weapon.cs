using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponData WeaponData;

    public int Dmg { get; set; }

    public float Fire_rate { get; set; }
    public float Multi_shot { get; set; }

    public float Bullet_speed { get; set; }
    public float Bullet_life { get; set; }

    public float Accuracy { get; set; }

    public float Charge_time { get; set; }
    public float Charge_speed { get; set; }
    public float Charge_fall_speed { get; set; }

    private GameObject Bullet;

    private float attack_time;
    private float cd;
    private float charge;
    private float acc;

    // Start is called before the first frame update
    void Start()
    {
        Init();

        cd = 1f / Fire_rate;
        Debug.Log(cd);
        attack_time = Time.time;
        acc = 100f - Accuracy;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInput.instance.charge)
        {
            if(charge > Charge_time)
            {
                ChargeAttack();
                charge = 0f;
            }
            else
            {
                charge += Time.deltaTime * Charge_speed;
            }
        }
        else
        {
            if (Time.time > attack_time)
            {
                Attack();
                Debug.Log(Time.time);
                attack_time = Time.time + cd;
            }

            if(charge > 0f)
            {
                charge -= Time.deltaTime * Charge_fall_speed;
            }
            else
            {
                charge = 0;
            }
        }

    }

    private void Init()
    {
        Dmg = WeaponData.dmg;
        Fire_rate = WeaponData.fire_rate;
        Multi_shot = WeaponData.multi_shot;
        Bullet_speed = WeaponData.bullet_speed;
        Bullet_life = WeaponData.bullet_life;
        Accuracy = WeaponData.accuracy;
        Charge_time = WeaponData.charge_time;
        Charge_speed = WeaponData.charge_speed;
        Charge_fall_speed = WeaponData.charge_fall_speed;
        Bullet = WeaponData.bullet;
    }

    protected virtual void Attack()
    {
        Bullet b;

        if (Multi_shot == 1)
        {
            b = Instantiate(Bullet, transform.position, Quaternion.identity).GetComponent<Bullet>();
            b.Accuracy = acc;
            b.Dmg = Dmg;
            b.speed = Bullet_speed;
            b.Life = Bullet_life;
        }
        else
        {
            for(int i = 0; i < (int)Multi_shot; i++)
            {
                b = Instantiate(Bullet, transform.position, Quaternion.identity).GetComponent<Bullet>();
                b.Accuracy = acc;
                b.Dmg = Dmg;
                b.speed = Bullet_speed;
                b.Life = Bullet_life;
            }

            if(Random.Range(0.0f, 1.0f) < Multi_shot % 1.0f)
            {
                b = Instantiate(Bullet, transform.position, Quaternion.identity).GetComponent<Bullet>();
                b.Accuracy = acc;
                b.Dmg = Dmg;
                b.speed = Bullet_speed;
                b.Life = Bullet_life;
            }
        }
    }

    protected virtual void ChargeAttack()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, 0, -acc / 2f) * transform.up);
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, 0, acc / 2f) * transform.up);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.up * 0.5f);
    }
}
