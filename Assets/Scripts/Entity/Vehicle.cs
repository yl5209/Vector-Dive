using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public abstract class Vehicle : MonoBehaviour
{
    protected Vector2 pos;
    protected Vector2 dir;
    protected Vector2 acc;
    public Vector2 vel;

    public float speed = 1.0f;

    public bool follow_vel;

    protected Rigidbody2D rb;

    protected Vector2 debug_acc;

    protected virtual void Start()
    {
        pos = transform.position;
        rb = gameObject.GetComponentInChildren<Rigidbody2D>();
    }

    protected virtual void Update()
    {

    }

    protected virtual void FixedUpdate()
    {
        rb.velocity = vel;

        pos = transform.position;

        acc = Vector2.zero;
    }

    public virtual void ApplyForce(Vector2 force)
    {
        acc += force / rb.mass;
    }

    public void ApplyEnvironmentalForce(Vector2 force)
    {
        acc += force / rb.mass;
    }

    protected virtual void CalculateVelocity()
    {
        vel += acc * Time.fixedDeltaTime;
    }

    protected virtual void CalculateRotation()
    {
        if (follow_vel)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg), Time.fixedDeltaTime * 10f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Util.Vec2_Vec3(vel));

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + Util.Vec2_Vec3(debug_acc));

        Gizmos.color = Color.blue;
        //Gizmos.DrawWireSphere(transform.position, 0.5f);
        //Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, 0, -turn_angle / 2) * transform.up);
        //Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, 0, turn_angle / 2) * transform.up);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.up * 0.5f);
    }
}
