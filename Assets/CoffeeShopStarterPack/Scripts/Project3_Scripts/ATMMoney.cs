using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zinnia.Tracking.Collision;

public class ATMMoney : MonoBehaviour
{
    public AudioSource atm_sound;
    public GameObject prefab;
    public Vector3 spawnPosition;

    public bool is_empty;
    void Start()
    {
        is_empty = true;
    }

    public void button_pressed(CollisionNotifier.EventData data)
    {
        
        Collider[] hitColliders = Physics.OverlapSphere(spawnPosition, 0.25f);
        foreach( Collider collider in hitColliders )
                    {
                        if (collider.name == "Money")
                        {
                            is_empty = false;
                            break;
                        }
                        else
                            {
                                is_empty = true;
                            }
                    }
        if(!atm_sound.isPlaying && is_empty)
        {
            atm_sound.Play ();
            StartCoroutine(process_item());
        }
        
    }
    public IEnumerator process_item()
    {
        yield return new WaitWhile (()=> atm_sound.isPlaying);
        Instantiate(prefab, spawnPosition, Quaternion.identity);
        
     }

}
