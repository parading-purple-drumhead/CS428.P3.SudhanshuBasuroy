using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSkybox : MonoBehaviour
{
    public Material original;
    public Material night;
    public GameObject day1;
    public bool is_off;
    void Start()
    {
        is_off = false;
        original = RenderSettings.skybox;
    }

    
    public void change_night()
    {
        is_off=!is_off;
        if(is_off)
        {
            day1.SetActive(false);
            RenderSettings.skybox = night;
        }
        else
        {
            RenderSettings.skybox = original;
        }
    }
    
}
