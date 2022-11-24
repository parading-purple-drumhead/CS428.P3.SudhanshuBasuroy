using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zinnia.Tracking.Collision;

public class FillCup : MonoBehaviour
{
    public AudioSource machine_sound;
    public GameObject fill;
    public GameObject fill_particle;
    public GameObject snap_zone;
    public Vector3 spawnPosition;
    public bool is_placed;

    void Start()
    {
        // Debug.Log("Item Touched!!!!");
        is_empty = false;
        enabled = true;
    }

    public void button_pressed(CollisionNotifier.EventData data)
    {
        Collider[] hitColliders = Physics.OverlapSphere(spawnPosition, 0.25f);
        string log = "";
        foreach (Collider collider in hitColliders)
        {
            // if (collider.name == "Chips" || collider.name == "Hersheys" || collider.name == "Candy")
            // {
            //     is_empty = false;
            //     break;
            // }
            // else
            // {
            //     is_empty = true;
            // }
            log = log + " " + collider.name;
        }
        Debug.Log($"{log}");
        if (!machine_sound.isPlaying && is_empty)
        {
            machine_sound.Play();
            StartCoroutine(process_item());
            // Instantiate(prefab, spawnPosition, Quaternion.identity);
        }
    }

    public IEnumerator process_item()
    {
        yield return new WaitWhile(() => machine_sound.isPlaying);
        Instantiate(fill, spawnPosition, Quaternion.identity);
    }
    void Update()
    {

    }
}
