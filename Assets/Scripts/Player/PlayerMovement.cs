using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;


public class PlayerMovement : Vehicle
{
    #region Player Rotation Field
    [SerializeField]
    [Range(1f, 2f)]
    private float look_distance;
    [SerializeField]
    [Range(0.01f, 0.3f)]
    private float rotate_speed;
    [SerializeField]
    [Range(10f, 100f)]
    private float rotate_slerp_speed = 70;
    private Vector2 look_point;
    private Vector2 velocity;
    private Vector3 velocity_v3;
    #endregion

    [SerializeField]
    [Range(0.8f, 1f)]
    public float friction = 0.98f;



    protected override void FixedUpdate()
    {
        PlayerMove();

        CalculateVelocity();

        base.FixedUpdate();

        CalculateRotation_v3();
    }

    private void LateUpdate()
    {

    }

    protected override void CalculateRotation()
    {
        Vector2 target = Global.instance.MousePosition;
        float angle = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x);
        target = Util.Vec3_Vec2(transform.position) + new Vector2(look_distance * Mathf.Cos(angle), look_distance * Mathf.Sin(angle));

        if (Vector2.Distance(look_point, transform.position) < look_distance)
        {
            float temp = Mathf.Atan2(look_point.y - transform.position.y, look_point.x - transform.position.x);
            look_point = Util.Vec3_Vec2(transform.position) + new Vector2(look_distance * Mathf.Cos(temp), look_distance * Mathf.Sin(temp));
        }

        look_point = Vector2.SmoothDamp(look_point, target, ref velocity, rotate_speed);
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(look_point.y - Util.Vec3_Vec2(transform.position).y, look_point.x - Util.Vec3_Vec2(transform.position).x) * Mathf.Rad2Deg + 90f);
    }

    protected void CalculateRotation_v3()
    {
        Vector3 target = Global.instance.MousePosition_v3;
        float angle = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x);
        target = transform.position + new Vector3(look_distance * Mathf.Cos(angle), look_distance * Mathf.Sin(angle), 0f);

        if (Vector3.Distance(look_point, transform.position) < look_distance)
        {
            float temp = Mathf.Atan2(look_point.y - transform.position.y, look_point.x - transform.position.x);
            look_point = transform.position + new Vector3(look_distance * Mathf.Cos(temp), look_distance * Mathf.Sin(temp), 0f);
        }

        //look_point = Vector3.SmoothDamp(look_point, target, ref velocity_v3, rotate_speed);
        look_point = Vector3.Slerp(look_point, target, Time.deltaTime * rotate_slerp_speed);

        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(look_point.y - Util.Vec3_Vec2(transform.position).y, look_point.x - Util.Vec3_Vec2(transform.position).x) * Mathf.Rad2Deg + 90f);
    }

    protected override void CalculateVelocity()
    {
        //base.CalculateVelocity();
        /*
         * Apply Friction If:
         * - No input
         * - Input Disabled
         * - Input direction in the opposite of velocity
         */
        //if(PlayerInput.instance.raw.magnitude == 0 || PlayerInput.instance.isDisabled || (Vector2.Dot(PlayerInput.instance.raw, vel) < 0f && PlayerInput.instance.raw.magnitude != 0))
        //{
        //    vel *= friction;
        //}

        //vel = Vector2.ClampMagnitude(vel, max_speed);
    }

    public override void ApplyForce(Vector2 force)
    {
        force *= speed;
        base.ApplyForce(force);
    }

    private void PlayerMove()
    {
        ApplyForceRb(PlayerInput.instance.Raw * speed);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(look_point, 1f);
    }

    public Vector2 GetLookPoint()
    {
        return look_point;
    }
}
