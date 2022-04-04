using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wwise_SFXController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonHover()
    {
        AkSoundEngine.PostEvent("Hover", gameObject);
    }

    public void ButtonClick()
    {
        AkSoundEngine.PostEvent("Select", gameObject);
    }
}
