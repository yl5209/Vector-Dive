using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public abstract class Agent : Vehicle
{
    protected Vector2 target_seek;
    protected Vector2 target_avoid;

    public float turn_speed = 0.5f;
    [SerializeField]
    [Range(10,360)]
    public float turn_angle = 200.0f;

    protected override void FixedUpdate()
    {
        CalculateTargets();

        CalculateForces();

        CalculateRotation();

        base.FixedUpdate();
    }

    public override void ApplyForce(Vector2 force)
    {
        //restrict steering angle
        if (Vector2.Angle(transform.up, force.normalized) <= turn_angle / 2)
        {
            force.Normalize();
            force *= speed;
            force = Vector2.ClampMagnitude(force, speed);

        }
        else
        {
            Debug.Log("Side");
            if (Vector2.Dot(force, transform.right) >= 0)
            {
                force = Quaternion.Euler(0, 0, -turn_angle / 2) * transform.up;
            }
            else
            {
                force = Quaternion.Euler(0, 0, turn_angle / 2) * transform.up;
            }

            force.Normalize();
            force *= turn_speed;
            force = Vector2.ClampMagnitude(force, turn_speed);
        }

        debug_acc = force;

        base.ApplyForceRb(force);
    }

    protected abstract void CalculateTargets();

    protected abstract void CalculateForces();

    protected Vector2 Seek(Vector2 target_pos)
    {
        Vector2 desiredVelocity = target_pos - Util.Vec3_Vec2(transform.position);

        desiredVelocity.Normalize();
        desiredVelocity = desiredVelocity * max_speed;

        Vector2 seekingForce = desiredVelocity - rb.velocity;
        return seekingForce;
    }

    protected Vector2 Seek(GameObject target)
    {
        return Seek(target.transform.position);
    }

    protected Vector2 Pursue(GameObject target)
    {
        Vehicle v = target.GetComponent<Vehicle>();
        return Seek(Util.Vec3_Vec2(target.transform.position) + rb.velocity);
    }

    public Vector2 Flee(Vector2 target_pos)
    {
        Vector2 desiredVelocity = pos - target_pos;

        desiredVelocity.Normalize();
        desiredVelocity = desiredVelocity * max_speed;

        Vector2 fleeingForce = desiredVelocity - rb.velocity;
        return fleeingForce;
    }

    public Vector2 Flee(GameObject target)
    {
        return Flee(target.transform.position);
    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.green;
        //Gizmos.DrawLine(transform.position, transform.position + a);

        //Gizmos.color = Color.yellow;
        //Gizmos.DrawLine(transform.position, transform.position + b);

        //Gizmos.color = Color.blue;
        ////Gizmos.DrawWireSphere(transform.position, 0.5f);
        ////Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, 0, -turn_angle / 2) * transform.up);
        ////Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, 0, turn_angle / 2) * transform.up);

        //Gizmos.color = Color.red;
        //Gizmos.DrawLine(transform.position, transform.position + c);
    }
}
