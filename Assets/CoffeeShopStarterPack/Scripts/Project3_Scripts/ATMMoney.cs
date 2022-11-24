using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zinnia.Tracking.Collision;

public class ATMMoney : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource atm_sound;
    public GameObject prefab;
    public Vector3 spawnPosition;
    void Start()
    {
        // Debug.Log("Item Touched!!!!");s
    }

    public void generate_money(CollisionNotifier.EventData data)
    {
        
        if(!atm_sound.isPlaying)
        {
            atm_sound.Play ();
            StartCoroutine(process_bill());
            // Instantiate(prefab, spawnPosition, Quaternion.identity);
        }
        
    }
    public IEnumerator process_bill()
    {
        yield return new WaitWhile (()=> atm_sound.isPlaying);
        Instantiate(prefab, spawnPosition, Quaternion.identity);
        
     }
}
