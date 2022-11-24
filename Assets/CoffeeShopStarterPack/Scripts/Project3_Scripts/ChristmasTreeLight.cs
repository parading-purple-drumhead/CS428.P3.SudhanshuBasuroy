using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChristmasTreeLight : MonoBehaviour
{
    Material lights;
    public bool is_on;
    public GameObject obj;
    public AudioSource lever_sound;
    
    public void Start()
    {
         
         
         lights = obj.GetComponent<Renderer>().sharedMaterial;
         is_on = false;
    }

    public void lever_moved()
    {
        is_on = !is_on;
        if(!lever_sound.isPlaying&is_on)
        {
            lever_sound.Play();
            lights.EnableKeyword("_EMISSION");
        }
        else
        {
            lights.DisableKeyword("_EMISSION");
        }
        
    }
}
