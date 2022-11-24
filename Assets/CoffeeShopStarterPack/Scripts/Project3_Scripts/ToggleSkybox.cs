using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSkybox : MonoBehaviour
{
    public Material original;
    public bool is_off;
    void Start()
    {
        is_off = false;
        original = RenderSettings.skybox;
    }

    
    void Update()
    {
        //is_off=!is_off;
        if(is_off)
        {
            RenderSettings.skybox = (null);
        }
        else
        {
            RenderSettings.skybox = original;
        }
    }
    
}
