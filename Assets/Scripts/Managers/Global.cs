using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Global : MonoBehaviour
{
    public static Global instance;

    public Vector2 MousePosition;
    public Vector3 MousePosition_v3;

    private void Awake()
    {
        instance = this;

        
    }

    public bool Debug_Mode = false;

    private void Update()
    {
        MousePosition = CameraManager.instance.main_camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void LateUpdate()
    {
        MousePosition_v3 = GetWorldPositionOnPlane(Utility.Util.Vec2_Vec3(Input.mousePosition), 0f);
    }

    public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z)
    {
        Ray ray = CameraManager.instance.main_camera.ScreenPointToRay(screenPosition);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }
}
