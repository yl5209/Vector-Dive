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

    public float _transition_time;
    public static float transiton_time;

    private void Awake()
    {
        instance = this;
        main_camera = _main_camera;
        cursor_camera = _cursor_camera;
        transiton_time = _transition_time;
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
        main_camera.DOColor(Random.ColorHSV(0.0f, 1.0f, 0.3f, 0.65f, 0.3f, 0.65f), transiton_time).SetEase(Ease.OutCirc);
    }

    public static void ChangeColor(Color color)
    {
        main_camera.DOColor(color, transiton_time).SetEase(Ease.OutCirc);
    }

    public static void Dive()
    {
        main_camera.GetComponent<CameraDive>().DoDive();
    }

    public static bool CheckDive()
    {
        return main_camera.GetComponent<CameraDive>().IsDiving;
    }
}
