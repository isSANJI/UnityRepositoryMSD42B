using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{

    [SerializeField] List<Transform> waypoints;

    [SerializeField] float enemySpeed = 12f;

    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        //set the Enemy position to the first waypoint
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    private void EnemyMovement()
    {
        if(waypointIndex < waypoints.Count)
        {
            //set the targetPosition to the position of our next wayPoint
            Vector3 targetPosition = waypoints[waypointIndex].transform.position;
            targetPosition.z = 0f;

            float movementThisFrame = enemySpeed * Time.deltaTime;
            
            //move the enemy from its current position towards the targetPosition
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if(transform.position == targetPosition)
            {
                waypointIndex++;
            }

            

        }
        //if enemy moved to all waypoints
        else
        {
            Destroy(gameObject);
        }


    }
}
