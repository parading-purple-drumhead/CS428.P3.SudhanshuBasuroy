using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChristmasTreeLight : MonoBehaviour
{
    public Material lights;
    public bool is_on;
    // Start is called before the first frame update
    void Start()
    {
         
         lights = GetComponent<Material>();
         is_on = false;
    }

    void Update()
    {
        
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
