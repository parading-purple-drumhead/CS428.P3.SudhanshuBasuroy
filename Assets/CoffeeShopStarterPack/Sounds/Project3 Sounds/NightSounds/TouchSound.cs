using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSound : MonoBehaviour
{
    public AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    public void play_sound()
    {
        if(!sound.isPlaying)
        {
            sound.Play();
        }
    }
}
