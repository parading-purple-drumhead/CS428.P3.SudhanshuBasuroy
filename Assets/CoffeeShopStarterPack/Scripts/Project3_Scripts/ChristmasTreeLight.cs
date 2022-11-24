using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChristmasTreeLight : MonoBehaviour
{
    Material lights;
    public bool is_on;
    public GameObject obj;
    public AudioSource lever_sound;
    public GameObject tree;
    public float rotationleft=360;
    [SerializeField] float rotationspeed=10;
    
    public void Start()
    {
         
         enabled = false;
         lights = obj.GetComponent<Renderer>().sharedMaterial;
         is_on = false;
    }

    public void lever_moved()
    {
        
        is_on = !is_on;
        if(!lever_sound.isPlaying&is_on&!enabled)
        {
            lever_sound.Play();
            enabled = true;
            lights.EnableKeyword("_EMISSION");
        }
        else
        {
            enabled=false;
            lights.DisableKeyword("_EMISSION");
        }
        
    }
    void Update()
    {
        
        float rotation=rotationspeed*Time.deltaTime;
        // if (rotationleft > rotation)
        // {
        //     rotationleft-=rotation;
        // }
        // else
        // {
        //     rotation=rotationleft;
        //     rotationleft=0;
        // }
        tree.transform.Rotate(0,rotation,0);
    }
}
