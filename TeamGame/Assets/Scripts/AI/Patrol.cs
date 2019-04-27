using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Stats", menuName ="Stats/Actions")]
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
            controller.nextWaypoint = (controller.nextWaypoint + 1) % controller.wayPoints.Count;
        }
    }
}
