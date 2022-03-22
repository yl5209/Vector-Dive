using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraDive : MonoBehaviour
{

    public float duration = 0.5f;

    private CameraFollow cameraFollow;
    private Tween dive;

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

    void DoDive()
    {
        cameraFollow.enabled = false;
        dive = transform.DOMove(new Vector3(Player.instance.transform.position.x, Player.instance.transform.position.y, 1), duration).SetEase(Ease.InBack).OnComplete(() => {
            transform.position = new Vector3(transform.position.x, transform.position.y, -1000f);
            cameraFollow.enabled = true;
            CameraManager.instance.main_camera.DOColor(Random.ColorHSV(0.0f, 1.0f, 0.3f, 0.7f, 0.5f, 0.8f), duration);
        }).Pause().SetAutoKill(false);
        dive.Restart();
    }
}
