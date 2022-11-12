using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zinnia.Tracking.Collision;

public class SpawnVendingObject : MonoBehaviour
{
    public AudioSource vending_sound;

    public GameObject prefab;

    public Vector3 spawnPosition;

    public bool is_empty;

    void Start()
    {
        // Debug.Log("Item Touched!!!!");
        is_empty = true;
    }

    public void button_pressed(CollisionNotifier.EventData data)
    {
        Collider[] hitColliders = Physics.OverlapSphere(spawnPosition, 0.25f);
        string log = "";
        foreach (Collider collider in hitColliders)
        {
            if (collider.name == "Chips" || collider.name == "Hersheys" || collider.name == "Candy")
            {
                is_empty = false;
                break;
            }
            else
            {
                is_empty = true;
            }
        }
        Debug.Log($"{log}");
        if (!vending_sound.isPlaying && is_empty)
        {
            vending_sound.Play();
            StartCoroutine(process_item());
            // Instantiate(prefab, spawnPosition, Quaternion.identity);
        }
    }

    public IEnumerator process_item()
    {
        yield return new WaitWhile(() => vending_sound.isPlaying);
        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }
}
