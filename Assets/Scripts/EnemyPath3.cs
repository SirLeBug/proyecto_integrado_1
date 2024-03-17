using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyPath3 : MonoBehaviour
{
    // ------------------------------------------------
    // Public variables, visible in Unity Inspector
    // Use these for settings for your script
    // that can be changed easily
    // ------------------------------------------------
    public float forceStrength;     // How fast we move
    public float stopDistance;      // How close we get before moving to next patrol point
    private Vector2[] patrolPoints;  // List of patrol points we will go between
    public GameObject[] waypoints;

    // ------------------------------------------------
    // Private variables, NOT visible in the Inspector
    // Use these for tracking data while the game
    // is running
    // ------------------------------------------------
    private int currentPoint = 0;       // Index of the current point we're moving towards
    private Rigidbody2D ourRigidbody;   // The rigidbody attached to this object

    // ------------------------------------------------
    // Awake is called when the script is loaded
    // ------------------------------------------------
    void Awake()
    {
        // Get the rigidbody that we'll be using for movement
        ourRigidbody = GetComponent<Rigidbody2D>();
        patrolPoints = new Vector2[0];
        foreach (GameObject waypoint in waypoints)
        {
            System.Array.Resize(ref patrolPoints, patrolPoints.Length + 1);
            patrolPoints[patrolPoints.Length - 1] = waypoint.transform.position;
            Debug.Log("Array size: " + patrolPoints.Length);
        }
    }


    // ------------------------------------------------
    // Update is called once per frame
    // ------------------------------------------------
    void Update()
    {
        // How far away are we from the target?
        float distance = (patrolPoints[currentPoint] - (Vector2)transform.position).magnitude;

        // If we are closer to our target than our minimum distance...
        if (distance <= stopDistance)
        {
            // Update to the next target
            currentPoint = currentPoint + 1;

            // If we've gone past the end of our list...
            // (if our current point index is equal or bigger than
            // the length of our list)
            if (currentPoint >= patrolPoints.Length)
            {
                // ...loop back to the start by setting 
                // the current point index to 0
                currentPoint = 0;
            }
        }

        // Now, move in the direction of our target

        // Get the direction
        // Subtract the current position from the target position to get a distance vector
        // Normalise changes it to be length 1, so we can then multiply it by our speed / force
        Vector2 direction = (patrolPoints[currentPoint] - (Vector2)transform.position).normalized;

        // Move in the correct direction with the set force strength
        ourRigidbody.AddForce(direction * forceStrength);
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        //Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        //Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);

        foreach(GameObject waypoint in waypoints)
        {
            Gizmos.DrawWireSphere(waypoint.transform.position, 0.5f);
        }
    }
}
