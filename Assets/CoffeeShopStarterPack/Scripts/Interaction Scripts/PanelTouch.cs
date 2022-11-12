using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zinnia.Tracking.Collision;

public class PanelTouch : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource panel_sound;
    public GameObject prefab;
    public Vector3 spawnPosition;
    void Start()
    {
        // Debug.Log("Item Touched!!!!");s
    }

    public void panel_collision(CollisionNotifier.EventData data)
    {
        
        if(!panel_sound.isPlaying)
        {
            panel_sound.Play ();
            StartCoroutine(process_bill());
            // Instantiate(prefab, spawnPosition, Quaternion.identity);
        }
        
    }
    public IEnumerator process_bill()
    {
        yield return new WaitWhile (()=> panel_sound.isPlaying);
        Instantiate(prefab, spawnPosition, Quaternion.identity);
        
     }
}
