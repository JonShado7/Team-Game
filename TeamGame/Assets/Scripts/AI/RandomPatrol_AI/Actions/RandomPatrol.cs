using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Stats/Actions/Random Patrol")]
public class RandomPatrol : Action
{

    public override void Act(StateController controller)
    {
        // calling the private function random patrol action
        RandomPatrolAction(controller);
    }

    private void RandomPatrolAction(StateController controller)
    {
        // Setting the local List to the controller waypoints list
        List<Transform> wayList = controller.wayPoints;

        // setting the destination
        controller.agent.destination = controller.wayPoints[controller.nextWaypoint].position;
        // ai is moving
        controller.agent.isStopped = false;

        if (controller.agent.remainingDistance <= controller.agent.stoppingDistance && !controller.agent.pathPending)
        {
            // Decreasing the search duration
            controller.mageStats.searchDuration -= Time.deltaTime;
            // ai is not moving
            controller.agent.isStopped = true;

            // if the duration reaches 0
            if (controller.mageStats.searchDuration <= 0)
            {
                // ai is moving again
                controller.agent.isStopped = false;
                // setting the next patrol point to be random within the count of the list
                controller.nextWaypoint = Random.Range(0, controller.wayPoints.Count);
                // setting the next waypoint
                controller.nextWaypoint = (controller.nextWaypoint + 1) % wayList.Count;
                // resetting the search duration timer
                controller.mageStats.searchDuration = 4;
            }

        }
    }
}
