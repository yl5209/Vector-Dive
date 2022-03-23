using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponData WeaponData;
    public int Dmg { get; set; }
    public DmgType dmg_type { get; set; }
    public float Fire_rate { get; set; }
    public int Multi_shot { get; set; }
    public float Bullet_speed { get; set; }
    public float Bullet_speed_offset { get; set; }
    public float Bullet_life { get; set; }
    public float Bullet_force { get; set; }
    public int Pierce { get; set; }
    public int Burst { get; set; }
    public float Burst_rate { get; set; }
    public float Accuracy { get; set; }
    public float Charge_time { get; set; }
    public float Charge_speed { get; set; }
    public float Charge_fall_speed { get; set; }
    public GameObject Bullet { get; set; }
    public bool Equal_division { get; set; }

    private float attack_time;
    private float cd;
    private float charge;
    private float acc;
    private int burst_count;
    private int angle_count;

    // Start is called before the first frame update
    void Start()
    {
        Init();

        attack_time = Time.time;
        cd = 1f / Fire_rate;
        acc = (100f - Accuracy) / 100f * 360f;
        burst_count = Burst;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInput.instance.charge)
        {
            if (charge > Charge_time)
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
                attack_time = Time.time + cd;
            }

            if (charge > 0f)
            {
                charge -= Time.deltaTime * Charge_fall_speed;
            }
            else
            {
                charge = 0;
            }
        }

        Debug.Log(cd);

    }

    private void Init()
    {
        Dmg = WeaponData.dmg;
        dmg_type = WeaponData.dmg_type;

        Fire_rate = WeaponData.fire_rate;
        Multi_shot = WeaponData.multi_shot;

        Bullet_speed = WeaponData.bullet_speed;
        Bullet_speed_offset = WeaponData.bullet_speed_offet;
        Bullet_life = WeaponData.bullet_life;
        Bullet_force = WeaponData.bullet_force;

        Pierce = WeaponData.pierce;
        Burst = WeaponData.burst;
        Burst_rate = WeaponData.burst_rate;

        Accuracy = WeaponData.accuracy;

        Charge_time = WeaponData.charge_time;
        Charge_speed = WeaponData.charge_speed;
        Charge_fall_speed = WeaponData.charge_fall_speed;

        Bullet = WeaponData.bullet;

        Equal_division = WeaponData.equal_division;
    }

    protected virtual void Attack()
    {
        if (Burst != 0)
        {
            if (burst_count > 0)
            {
                cd = 1 / Burst_rate;
            }
            else
            {
                cd = 1 / Fire_rate;
                burst_count = Burst;
            }
        }

        if (Multi_shot == 1)
        {
            InstantiateBullet();
        }
        else
        {
            for (int i = 0; i < Multi_shot; i++)
            {
                InstantiateBullet();
            }
        }

        burst_count--;
    }

    private Bullet InstantiateBullet()
    {
        Bullet b;
        b = Instantiate(Bullet, transform.position, Quaternion.identity).GetComponent<Bullet>();
        b.Dmg = Dmg;
        b.Dmg_type = dmg_type;

        b.speed = Bullet_speed;
        b.Life = Bullet_life;
        b.Force = Bullet_force;

        b.Life_count = Pierce;

        b.Accuracy = acc;
        b.Type = EntityType.Player;

        return b;
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
