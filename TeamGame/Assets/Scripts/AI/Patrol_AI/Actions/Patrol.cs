using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Stats", menuName ="Stats/Actions/Patrol")]
public class Patrol : Action
{
    public override void Act(StateController controller)
    {
        PatrolAction(controller);
    }

    private void PatrolAction(StateController controller)
    {
        controller.agent.destination = controller.wayPoints[controller.nextWaypoint].position;
        controller.agent.isStopped = false;

        if(controller.agent.remainingDistance <= controller.agent.stoppingDistance && !controller.agent.pathPending)
        {
            controller.enemyStats.searchDuration -= Time.deltaTime;
            controller.agent.isStopped = true;

            if (controller.enemyStats.searchDuration <= 0)
            {
                controller.agent.isStopped = false;
                controller.nextWaypoint = (controller.nextWaypoint + 1) % controller.wayPoints.Count;
                controller.enemyStats.searchDuration = 4;
            }
            
        }
    }
}
