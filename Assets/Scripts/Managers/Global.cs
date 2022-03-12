using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public static Global instance;

    public Vector2 MousePosition;

    private void Awake()
    {
        instance = this;
    }

    public bool Debug_Mode = false;

    private void Update()
    {
        MousePosition = CameraManager.instance.main_camera.ScreenToWorldPoint(Input.mousePosition);
    }
}
