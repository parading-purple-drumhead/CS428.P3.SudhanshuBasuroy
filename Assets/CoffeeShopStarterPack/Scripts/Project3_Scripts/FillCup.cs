// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Zinnia.Tracking.Collision;

// public class FillCup : MonoBehaviour
// {
//     public AudioSource machine_sound;

//     public GameObject fill;

//     public GameObject fill_particle;

//     public GameObject snap_zone;

//     public Vector3 spawnPosition;

//     public bool is_placed;

//     public bool is_empty;

//     void Start()
//     {
//         // Debug.Log("Item Touched!!!!");
//         is_empty = false;
//         enabled = true;
//     }

//     public void button_pressed(CollisionNotifier.EventData data)
//     {
//         Collider[] hitColliders = Physics.OverlapSphere(spawnPosition, 0.25f);
//         string log = "";
//         foreach (Collider collider in hitColliders)
//         {
//             // if (collider.name == "Chips" || collider.name == "Hersheys" || collider.name == "Candy")
//             // {
//             //     is_empty = false;
//             //     break;
//             // }
//             // else
//             // {
//             //     is_empty = true;
//             // }
//             log = log + " " + collider.name;
//         }
//         Debug.Log($"{log}");
//         if (!machine_sound.isPlaying && is_empty)
//         {
//             machine_sound.Play();
//             StartCoroutine(process_item());
//             // Instantiate(prefab, spawnPosition, Quaternion.identity);
//         }
//     }

//     public IEnumerator process_item()
//     {
//         yield return new WaitWhile(() => machine_sound.isPlaying);
//         Instantiate(fill, spawnPosition, Quaternion.identity);
//     }

//     void Update()
//     {
//     }
// }

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
    [SerializeField] float r;
    public Collider cup;
    public bool is_placed;

    void Start()
    {
        is_placed = false;
        r = 0.01f;
        fill_particle.SetActive(false);
        Debug.Log("Machine Button Activated");
    }

    public void machine_button(CollisionNotifier.EventData data)
    {
        // Check if space has cup
        // Particle system starts
        //As soon as filled, destroy old mug
        // Then turn off snapzone
        // Then spawn new object
        //string log = "";
        //Debug.Log("Machine Button Pressed");
        Collider[] hitColliders = Physics.OverlapSphere(spawnPosition, r);
        foreach (Collider collider in hitColliders)
        {
            if (collider.name == "Paper cup")
            {
                is_placed = true;
                if(!collider.transform.GetChild(0).gameObject.activeSelf)
                {
                    if (!machine_sound.isPlaying && is_placed)
                    {
                        
                        // snap_zone.SetActive(false);
                        machine_sound.Play();
                        fill_particle.SetActive(true);
                        // collider.transform.GetChild(0).gameObject.SetActive(true);
                        StartCoroutine(process_item(collider));
                    }
                }
            }
        }
        
        

    }

    public IEnumerator process_item(Collider c)
    {
        yield return new WaitWhile(() => machine_sound.isPlaying);
        fill_particle.SetActive(false);
        // safe_zone = snap_zone;
        // Destroy(c.gameObject);
        // Instantiate(fill, spawnPosition, Quaternion.identity);
        // snap_zone = safe_zone;
        // snap_zone.SetActive(true);
        c.transform.GetChild(0).gameObject.SetActive(true);
        
    }
    // void Update()
    // {
        
    //     if(is_placed)
    //     {
    //     // Debug.Log("Checking for objects");
    //     Collider[] hitColliders1 = Physics.OverlapSphere(spawnPosition, r);
    //     foreach (Collider collider in hitColliders1)
    //     {
    //         if (collider.name == "Paper cup" || collider.name == "Filled paper cup")
    //         {
    //             is_placed = true;
    //         }
    //         else
    //         {
               
    //             if(!snap_zone.activeSelf)
    //             {
    //                 Debug.Log("Snapzone reactivated");
    //                 is_placed = false;
    //                 snap_zone.SetActive(true);
    //                 // Instantiate(safe_zone);
                    
    //             }
    //         }
    //     }
    //     }
        
        
    // }

}
