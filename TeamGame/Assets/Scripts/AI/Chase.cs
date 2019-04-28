using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Stats/Chase Action")]
public class Chase : Action
{
    public override void Act(StateController controller)
    {
        ChaseAction(controller);

    }

    private void ChaseAction(StateController controller)
    {
        controller.agent.destination = controller.chaseTarget.position;
        controller.agent.isStopped = false;
    }
}
