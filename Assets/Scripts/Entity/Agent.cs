using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public abstract class Agent : Vehicle
{
    protected Vector2 target_seek;
    protected Vector2 target_avoid;

    public float turn_speed = 0.5f;
    public float turn_angle = 200.0f;

    protected override void FixedUpdate()
    {
        CalculateTargets();

        CalculateForces();

        debug_acc = acc;

        CalculateVelocity();

        dir = vel.normalized;

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
            if (Vector2.Dot(force, transform.right) >= 0)
            {
                force = Quaternion.Euler(0, 0, -turn_angle / 2) * transform.up;
                force.Normalize();
                force *= speed;
            }
            else
            {
                force = Quaternion.Euler(0, 0, turn_angle / 2) * transform.up;
                force.Normalize();
                force *= speed;
            }
        }

        base.ApplyForce(force);
    }

    protected abstract void CalculateTargets();

    protected abstract void CalculateForces();

    protected Vector2 Seek(Vector2 target_pos)
    {
        Vector2 desiredVelocity = target_pos - pos;

        desiredVelocity.Normalize();
        desiredVelocity = desiredVelocity * speed;

        Vector2 seekingForce = desiredVelocity - vel;
        return seekingForce;
    }

    protected Vector2 Seek(GameObject target)
    {
        return Seek(target.transform.position);
    }

    protected Vector2 Pursue(GameObject target)
    {
        Vehicle v = target.GetComponent<Vehicle>();
        return Seek(Util.Vec3_Vec2(target.transform.position) + v.vel);
    }

    public Vector2 Flee(Vector2 target_pos)
    {
        Vector2 desiredVelocity = pos - target_pos;

        desiredVelocity.Normalize();
        desiredVelocity = desiredVelocity * speed;

        Vector2 fleeingForce = desiredVelocity - vel;
        return fleeingForce;
    }

    public Vector2 Flee(GameObject target)
    {
        return Flee(target.transform.position);
    }
}
