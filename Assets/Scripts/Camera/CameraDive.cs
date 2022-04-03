using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraDive : MonoBehaviour
{

    public float duration = 0.5f;
    public float dive_depth = 1f;
    public float dive_height = 300f;
    public float fall_duration = 3f;
    public bool IsDiving { get; set; }

    private CameraFollow cameraFollow;
    private Tween dive;
    private Tween fall;


    void Start()
    {
        cameraFollow = GetComponent<CameraFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            DoDive();
        }
    }

    public void DoDive()
    {
        cameraFollow.look_at = false;
        IsDiving = true;
        dive = transform.DOMove(new Vector3(Player.instance.transform.position.x, Player.instance.transform.position.y, dive_depth), duration).SetEase(Ease.InBack).Pause().SetAutoKill(false).OnComplete(() =>
        {

            transform.position = new Vector3(transform.position.x, transform.position.y, -dive_height);
            CameraManager.main_camera.DOColor(Random.ColorHSV(0.0f, 1.0f, 0.3f, 0.7f, 0.5f, 0.8f), duration * 2f);
            cameraFollow.look_at = true;

            fall = transform.DOMove(new Vector3(Player.instance.transform.position.x, Player.instance.transform.position.y, -17f), fall_duration).SetEase(Ease.OutCirc).Pause().SetAutoKill(false).OnComplete(() =>
            {
                IsDiving = false;
                //cameraFollow.ResetVelocity();
            });
            fall.Restart();
        });
        dive.Restart();
    }
}
