using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChristmasTreeLight : MonoBehaviour
{
    Material lights;
    public bool is_on;
    public GameObject obj;
    
    public void Start()
    {
         
         
         lights = obj.GetComponent<Renderer>().sharedMaterial;
         is_on = false;
    }

    public void lever_moved()
    {
        is_on = !is_on;
        if(is_on)
        {
            lights.EnableKeyword("_EMISSION");
        }
        else
        {
            lights.DisableKeyword("_EMISSION");
        }
        
    }
}
