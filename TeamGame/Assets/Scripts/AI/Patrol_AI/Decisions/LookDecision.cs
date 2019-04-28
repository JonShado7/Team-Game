using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = ("Stat/Decisions"))]
public class LookDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        bool targetVisible = Look(controller);
        return targetVisible;
    }

    private bool Look(StateController controller)
    {
        RaycastHit hit;

        Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * controller.enemyStats.sightRange, Color.green);

        if (Physics.SphereCast(controller.eyes.position, controller.enemyStats.sphereLookRadius, controller.eyes.forward, out hit, controller.enemyStats.sightRange)
            && hit.collider.CompareTag("Player"))
        {
            controller.chaseTarget = hit.transform;
            Debug.Log("I am fucking here");
            return true;
        }
        else
        {
            return false;
        }
    }
}
