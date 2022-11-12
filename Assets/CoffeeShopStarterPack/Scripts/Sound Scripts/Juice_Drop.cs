using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juice_Drop : MonoBehaviour
{
    public AudioSource juice_sound;

    // Start is called before the first frame update
    void Start()
    {
        // can_sound = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("Hand Collision");
        if (collision.relativeVelocity.magnitude > 3) {
            if (!juice_sound.isPlaying) {
                Debug.Log($"{gameObject.name} is colliding with {collision.collider.name} with velocity {collision.relativeVelocity.magnitude} ");
                juice_sound.Play();
            }
        }
    }
}
