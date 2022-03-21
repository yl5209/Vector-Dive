using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 velocity_folllow;
    private Vector3 velocity_look;
    public bool look_at;

    [SerializeField]
    [Range(10f, 30f)]
    private float height;
    [SerializeField]
    [Range(0.01f, 10f)]
    private float follow_speed;
    [SerializeField]
    [Range(0.01f, 10f)]
    private float look_speed;
    private Vector3 look_point;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
    }

    private void LateUpdate()
    {
        FollowPlayer();
        if (look_at)
        {
            LookPlayer();
        }

    }

    void LookPlayer()
    {
        look_point = Vector3.SmoothDamp(look_point, new Vector3(Player.instance.PlayerMovement.GetLookPoint().x, Player.instance.PlayerMovement.GetLookPoint().y, 0), ref velocity_look, look_speed);
        //look_point = new Vector3(Player.instance.PlayerMovement.GetLookPoint().x, Player.instance.PlayerMovement.GetLookPoint().y, 0);
        transform.LookAt(look_point);
    }

    void FollowPlayer()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(Player.instance.PlayerMovement.GetLookPoint().x, Player.instance.PlayerMovement.GetLookPoint().y, -height), ref velocity_folllow, follow_speed);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(look_point, 0.5f);
    }

    public void SetFollowSpeed()
    {

    }
}
