using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketBallSpawn : MonoBehaviour
{
    // public AudioSource oven_sound;
    public GameObject prefab;
    public Vector3 spawnPosition;

    public bool is_spawning;
    void Start()
    {
        is_spawning = false;
    }

    public void button_pressed()
    {
        
        // if(!oven_sound.isPlaying && is_empty)
        // {
        //     oven_sound.Play ();
        //     StartCoroutine(process_item());
        // }
        if(!is_spawning)
        {
            is_spawning = true;
            Instantiate(prefab, spawnPosition, Quaternion.identity);
            StartCoroutine(process_item());
        }
        
        // Instantiate(prefab, spawnPosition, Quaternion.identity);
        
    }
    public IEnumerator process_item()
    {
        yield return new WaitForSeconds(3);
        is_spawning = false;
        
     }
}
