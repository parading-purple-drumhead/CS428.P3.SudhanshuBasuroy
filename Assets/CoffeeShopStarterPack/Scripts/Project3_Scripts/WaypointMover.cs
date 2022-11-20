using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    [SerializeField] private Waypoint waypoints;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float distanceThreshold = 0.1f;
    private Transform current;
    // Start is called before the first frame update
    void Start()
    {
        // Initial Waypoint
        current = waypoints.GetNextWaypoint(current);
        transform.position = current.position;
        current = waypoints.GetNextWaypoint(current);
        transform.LookAt(current);


    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,current.position,moveSpeed*Time.deltaTime);
        if(Vector3.Distance(transform.position,current.position) < distanceThreshold)
        {
            current = waypoints.GetNextWaypoint(current);
            transform.LookAt(current);
        }
        
    }
}
