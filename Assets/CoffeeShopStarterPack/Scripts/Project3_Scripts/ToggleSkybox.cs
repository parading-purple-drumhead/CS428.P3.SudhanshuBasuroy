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
    public GameObject day_obj; 
    public GameObject reindeer;
    public GameObject drone;

    //Night
    public GameObject halloween;
    public GameObject chandelier_main;
    public Material chandelier_emission;
    public GameObject chandelier_light1;
    public GameObject chandelier_light2;
    public GameObject chandelier_light3;
    //Irr
    public bool is_night;
    public bool was_pressed;
    void Start()
    {
        is_night = false;
        original = RenderSettings.skybox;
        chandelier_emission = chandelier_main.GetComponent<Renderer>().sharedMaterial;
        chandelier_emission.DisableKeyword("_EMISSION");
        was_pressed = false;
    }

    
    public void button_pressed(CollisionNotifier.EventData data)
    {
        Debug.Log("Code Run!");
        is_night=!is_night;
        if(!was_pressed)
        {
            was_pressed = true;
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
                
                //Emissions
                
                //Night Objects
                halloween.SetActive(true);
                RenderSettings.skybox = night;
                chandelier_emission.EnableKeyword("_EMISSION");
                chandelier_light1.SetActive(true);
                chandelier_light1.SetActive(true);
                chandelier_light1.SetActive(true);
            }
            else
            {
                StartCoroutine(process_item());
                //Day Objects
                day_obj.SetActive(true);
                reindeer.SetActive(true);
                drone.SetActive(true);
                
                //Night Objects
                halloween.SetActive(false);
                RenderSettings.skybox = original;
                chandelier_emission.DisableKeyword("_EMISSION");
                chandelier_light1.SetActive(false);
                chandelier_light1.SetActive(false);
                chandelier_light1.SetActive(false);
            }
        }
        
    }
    public IEnumerator process_item()
    {
        // yield return new WaitWhile (()=> cancelled.isPlaying);
        yield return new WaitForSeconds(5);
        was_pressed = false;
        
     }
    
}
