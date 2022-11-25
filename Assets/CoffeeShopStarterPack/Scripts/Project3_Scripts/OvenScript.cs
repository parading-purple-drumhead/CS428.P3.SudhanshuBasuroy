using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenScript : MonoBehaviour
{
    public AudioSource oven_sound;
    public GameObject prefab;
    public Vector3 spawnPosition;

    public bool is_empty;
    void Start()
    {
        is_empty = true;
    }

    public void button_pressed()
    {
        
        Collider[] hitColliders = Physics.OverlapSphere(spawnPosition, 0.25f);
        foreach( Collider collider in hitColliders )
                    {
                        if (collider.name == "ApplePie")
                        {
                            is_empty = false;
                            break;
                        }
                        else
                            {
                                is_empty = true;
                            }
                    }
        if(!oven_sound.isPlaying && is_empty)
        {
            oven_sound.Play ();
            StartCoroutine(process_item());
        }
        
    }
    public IEnumerator process_item()
    {
        yield return new WaitWhile (()=> oven_sound.isPlaying);
        Instantiate(prefab, spawnPosition, Quaternion.identity);
        
     }
}
