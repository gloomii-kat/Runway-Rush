using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelRoute : MonoBehaviour
{
    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private Transform[] waypoints;
    private int stoppingPoint;
    // Walk speed
    [SerializeField]
    private float moveSpeed = 2f;

    // Index of current waypoint from which the model walks from to the next one
    private int waypointIndex = 0;







    private void Start()
    {
        // Set position of enemy as position of the first waypoint
        transform.position = waypoints[waypointIndex].transform.position;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {

        if (waypointIndex < waypoints.Length)
        {
            // Move model from current waypoint to the next

            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

            // If model reaches position of waypoint he walked towards, then waypointIndex is increased by 1 and the model starts moving to the next one
            if (Vector2.Distance(transform.position, waypoints[waypointIndex].transform.position) < 0.01f)
            {
                // Move to the next waypoint
                waypointIndex++;
            }
        }
            /*
        else
        {
            // If the model reached the last waypoint, reset the index to 0 for looping
            waypointIndex = 0;*/
        //}
    }
}