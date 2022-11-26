using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zinnia.Tracking.Collision;

public class ToggleSkybox : MonoBehaviour
{
    public Material original;
    public Material night;
    public AudioSource cancelled;
    //Day
    public GameObject day_obj; //christmas
    public GameObject reindeer;
    public GameObject drone;
    public GameObject chandelier_main;
    public Material chandelier_emission;
    //Chandelier Emissions
    //L hallway lights

    //Night
    public GameObject halloween;
    //Irr
    public bool is_night;
    void Start()
    {
        is_night = false;
        original = RenderSettings.skybox;
        chandelier_emission = chandelier_main.GetComponent<Renderer>().sharedMaterial;
    }

    
    public void button_pressed(CollisionNotifier.EventData data)
    {
        Debug.Log("Code Run!");
        is_night=!is_night;
        if(is_night)
        {
            StartCoroutine(process_item());
            if(!cancelled.isPlaying)
            {
                cancelled.Play();
            }
            //Day Objects
            day_obj.SetActive(false);
            reindeer.SetActive(false);
            drone.SetActive(false);
            chandelier_emission.EnableKeyword("_EMISSION");
            //Emissions
            
            //Night Objects
            halloween.SetActive(true);
            RenderSettings.skybox = night;
        }
        else
        {
            StartCoroutine(process_item());
            //Day Objects
            day_obj.SetActive(true);
            reindeer.SetActive(true);
            drone.SetActive(true);
            chandelier_emission.DisableKeyword("_EMISSION");
            
            //Night Objects
            halloween.SetActive(false);
            RenderSettings.skybox = original;
        }
        
    }
    public IEnumerator process_item()
    {
        yield return new WaitWhile (()=> cancelled.isPlaying);
        yield return new WaitForSeconds(5);
        
     }
    
}
