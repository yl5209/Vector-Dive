using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteGlow : MonoBehaviour
{
    public float drop = 1f;
    public float glow = 5f;
    public float glow_time = 0.05f;

    private SpriteRenderer spriteRenderer;
    private Material mat;
    private Color base_color;
    private Color current_color;
    private float glow_timer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        mat = spriteRenderer.material;
        base_color = mat.GetColor("_Color");
        glow_timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        current_color = mat.GetColor("_Color");
        current_color = Color.Lerp(current_color, base_color, Time.deltaTime * drop);
        mat.SetColor("_Color", current_color);
    }

    public void SetGlowIntensity(float f)
    {
        float factor = Mathf.Pow(2, f);
        Color color = new Color(base_color.r * factor, base_color.g * factor, base_color.b * factor);
        mat.SetColor("_Color", color);
    }

    public void Glow()
    {
        if (Time.time > glow_timer)
        {
            float factor = Mathf.Pow(2, glow);
            Color color = new Color(base_color.r * factor, base_color.b * factor, base_color.r * factor);
            mat.SetColor("_Color", color);
            glow_timer = Time.time + glow_time;
        }
    }
}
