using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover1 : MonoBehaviour
{
    [SerializeField] private Waypoint waypoints;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float distanceThreshold = 0.1f;
    public GameObject obj;
    private Vector3 start;
    private Transform current;
    public bool is_on;
     public bool in_motion;
    // Start is called before the first frame update
    void Start()
    {
        // Initial Waypoint
        current = waypoints.GetNextWaypoint(current);
        obj.transform.position = current.position;
        start = current.position;
        current = waypoints.GetNextWaypoint(current);
        obj.transform.LookAt(current);
        is_on = false;
        in_motion = false;

    }
    public void set_on()
    {
        if(!is_on&&!in_motion)
        {
            is_on = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if(is_on&&!in_motion)
        {
            is_on = false;
            in_motion = true;
        }
        if(in_motion)
        {
            obj.transform.position = Vector3.MoveTowards(obj.transform.position,current.position,moveSpeed*Time.deltaTime);
            if(Vector3.Distance(obj.transform.position,current.position) < distanceThreshold)
            {
                if(Vector3.Distance(obj.transform.position,start) < distanceThreshold)
                {
                    in_motion = false;
                }
                current = waypoints.GetNextWaypoint(current);
                obj.transform.LookAt(current);
            }
            
        }
        
        
    }
}
