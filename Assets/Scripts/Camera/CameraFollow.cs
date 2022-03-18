using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 velocity;
    [SerializeField]
    [Range(0.01f, 0.3f)]
    private float follow_speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(Player.instance.PlayerMovement.GetLookPoint().x, Player.instance.PlayerMovement.GetLookPoint().y, -10), ref velocity, follow_speed);
    }
}
