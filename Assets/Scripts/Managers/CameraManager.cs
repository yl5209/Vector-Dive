using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;

    public Camera _main_camera;
    public Camera _cursor_camera;
    public static Camera main_camera;
    public static Camera cursor_camera;

    public static float transiton_time;

    private void Awake()
    {
        instance = this;
        main_camera = _main_camera;
        cursor_camera = _cursor_camera;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void ChangeColor()
    {
        main_camera.DOColor(Random.ColorHSV(0.0f, 1.0f, 0.3f, 0.7f, 0.5f, 0.8f), transiton_time);
    }

    public static void ChangeColor(Color color)
    {
        main_camera.DOColor(color, transiton_time);
    }
}
