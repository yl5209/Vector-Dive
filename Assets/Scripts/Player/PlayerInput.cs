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
    public Vector2 input
    {
        get
        {
            if (this.isDisabled) return Vector2.zero;

            Vector2 i = Vector2.zero;
            i.x = Input.GetAxis("Horizontal");
            i.y = Input.GetAxis("Vertical");
            i *= (i.x != 0.0f && i.y != 0.0f) ? .7071f : 1.0f;
            return i;
        }
    }

    public Vector2 raw
    {
        get
        {
            if (this.isDisabled) return Vector2.zero;

            Vector2 i = Vector2.zero;
            i.x = Input.GetAxisRaw("Horizontal");
            i.y = Input.GetAxisRaw("Vertical");
            i *= (i.x != 0.0f && i.y != 0.0f) ? .7071f : 1.0f;
            return i;
        }
    }

    public Vector2 mouseLook
    {
        get
        {
            if (this.isDisabled) return Vector2.zero;

            Vector2 i = Vector2.zero;
            i.x = Input.GetAxis("Mouse X");
            i.y = Input.GetAxis("Mouse Y");
            return i;
        }
    }

    public bool charge
    {
        get { if (this.isDisabled) return false; return Input.GetMouseButton(0); }
    }

}
