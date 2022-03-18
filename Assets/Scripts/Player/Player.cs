using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public static Player instance;
    public PlayerMovement PlayerMovement;

    private void Awake()
    {
        instance = this;

        if (!PlayerMovement)
        {
            PlayerMovement = GetComponent<PlayerMovement>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
