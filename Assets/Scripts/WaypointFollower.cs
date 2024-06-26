using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints = null;
    [SerializeField] private float speed = 2f;
    private int currWaypointIndex = 0;

    // Update is called once per frame
    void Update()
    {
        if(waypoints == null || waypoints.Length==0)
        {
            return;
        }
        if (Vector2.Distance(waypoints[currWaypointIndex].transform.position, transform.position) < .1f)
        {
            currWaypointIndex++;
            if (currWaypointIndex >= waypoints.Length)
            {
                currWaypointIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[currWaypointIndex].transform.position, Time.deltaTime * speed);

    }
}
