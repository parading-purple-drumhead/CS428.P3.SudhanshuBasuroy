using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can_Drop : MonoBehaviour
{
    public AudioSource can_sound;

    // Start is called before the first frame update
    void Start()
    {
        // can_sound = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("Hand Collision");
        if (collision.relativeVelocity.magnitude > 3) {
            if (!can_sound.isPlaying) {
                Debug.Log($"{gameObject.name} is colliding with {collision.collider.name} with velocity {collision.relativeVelocity.magnitude} ");
                can_sound.Play();
            }
        }
    }
}

// using UnityEngine;
// using Zinnia.Tracking.Collision;

// public class Can_Drop : MonoBehaviour
// {
//     public AudioSource can_sound;
//     void Start()
//     {
//         can_sound = GetComponent<AudioSource>(); 
//     }
//     public void can_collision(CollisionNotifier.EventData data)
//     {
//         Debug.Log("Colllision Detected");
//         if(!can_sound.isPlaying)
//         {
//             can_sound.Play();
//         }
//     }
// }