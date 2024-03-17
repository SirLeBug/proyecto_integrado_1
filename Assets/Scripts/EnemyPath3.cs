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
    
    public float forceStrength;     // How fast we move
    public float stopDistance;      // How close we get before moving to next patrol point
    private Vector2[] patrolPoints;  // List of patrol points we will go between
    public GameObject[] waypoints;

    
    private int currentPoint = 0;       // Index of the current point we're moving towards
    private Rigidbody2D ourRigidbody;   // The rigidbody attached to this object

    
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


    
    void Update()
    {
        // How far away are we from the target?
        float distance = (patrolPoints[currentPoint] - (Vector2)transform.position).magnitude;

        
        if (distance <= stopDistance)
        {
            // Update to the next target
            currentPoint = currentPoint + 1;

            
            if (currentPoint >= patrolPoints.Length)
            {
                // the current point index to 0
                currentPoint = 0;
            }
        }

        
        Vector2 direction = (patrolPoints[currentPoint] - (Vector2)transform.position).normalized;

        // Move in the correct direction with the set force strength
        ourRigidbody.AddForce(direction * forceStrength);
    }

    // Draws all waypoints
    private void OnDrawGizmos()
    {
        foreach(GameObject waypoint in waypoints)
        {
            Gizmos.DrawWireSphere(waypoint.transform.position, 0.5f);
        }
    }
}
