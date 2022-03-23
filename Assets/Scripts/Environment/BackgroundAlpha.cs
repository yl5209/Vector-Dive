using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAlpha : MonoBehaviour
{
    public Color color;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<MeshRenderer>().material.SetColor("_Color", color);
    }
}
