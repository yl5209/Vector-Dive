using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    public float force = 5.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Entity")
        {
            collision.gameObject.GetComponent<Vehicle>().ApplyEnvironmentalForce((collision.gameObject.transform.position - transform.position).normalized * force);
        }
    }
}
