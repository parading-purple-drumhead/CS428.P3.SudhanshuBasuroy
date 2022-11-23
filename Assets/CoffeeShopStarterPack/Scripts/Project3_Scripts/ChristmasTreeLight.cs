using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChristmasTreeLight : MonoBehaviour
{
    Material lights;
    public bool is_on;
    public GameObject obj;
    // public Transform[] children;
    // Start is called before the first frame update
    public void Start()
    {
         
         
         lights = obj.GetComponent<Renderer>().sharedMaterial;
        //  children = obj.GetComponentsInChildren<Transform>();
        //  Debug.Log(children);
         is_on = false;
    }

    public void lever_moved()
    {
        is_on = !is_on;
        if(is_on)
        {
            // foreach(Transform child in children)
            // {
            //     // GameObject temp = child.gameObject;
            //     // Debug.Log(temp.name);
            //     // Material lights = temp.material;
            //     // lights.EnableKeyword("_EMISSION");
            //     //Debug.Log(child);
            // }
            lights.EnableKeyword("_EMISSION");
        }
        else
        {
            //  foreach(Transform child in children)
            // {
            //     child.gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            // }
            lights.DisableKeyword("_EMISSION");
        }
        
    }
}
