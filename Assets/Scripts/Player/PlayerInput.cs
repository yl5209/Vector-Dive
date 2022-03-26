using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput instance;

    private void Awake()
    {
        instance = this;
    }

    public bool isDisabled;
    public Vector2 Input
    {
        get
        {
            if (this.isDisabled) return Vector2.zero;

            Vector2 i = Vector2.zero;
            i.x = UnityEngine.Input.GetAxis("Horizontal");
            i.y = UnityEngine.Input.GetAxis("Vertical");
            i *= (i.x != 0.0f && i.y != 0.0f) ? .7071f : 1.0f;
            return i;
        }
    }

    public Vector2 Raw
    {
        get
        {
            if (this.isDisabled) return Vector2.zero;

            Vector2 i = Vector2.zero;
            i.x = UnityEngine.Input.GetAxisRaw("Horizontal");
            i.y = UnityEngine.Input.GetAxisRaw("Vertical");
            i *= (i.x != 0.0f && i.y != 0.0f) ? .7071f : 1.0f;
            return i;
        }
    }

    public Vector2 MouseLook
    {
        get
        {
            if (this.isDisabled) return Vector2.zero;

            Vector2 i = Vector2.zero;
            i.x = UnityEngine.Input.GetAxis("Mouse X");
            i.y = UnityEngine.Input.GetAxis("Mouse Y");
            return i;
        }
    }

    public bool Charge
    {
        get { if (this.isDisabled) return false; return UnityEngine.Input.GetMouseButton(0); }
    }

    public bool Dive
    {
        get { if (this.isDisabled) return false; return UnityEngine.Input.GetKeyDown(KeyCode.Space); }
    }

}
