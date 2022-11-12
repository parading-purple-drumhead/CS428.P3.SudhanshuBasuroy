using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceScript : MonoBehaviour
{
    public AudioSource voice;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    public void play_voice()
    {
        if(!voice.isPlaying)
        {
            voice.Play();
        }
    }
}
