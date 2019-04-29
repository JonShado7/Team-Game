using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Stats/Actions/Cast Spell")]
public class CastSpell_Action : Action
{
    public override void Act(StateController controller)
    {
        CastSpell(controller);
    }

    private void CastSpell(StateController controller)
    {
        RaycastHit hit;

        Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * controller.mageStats.castRange, Color.red);

        if (Physics.SphereCast(controller.eyes.position, controller.mageStats.sphereLookRadius, controller.eyes.forward, out hit, controller.mageStats.castRange)
            && hit.collider.CompareTag("Player"))
        {
            if (controller.CheckTime(controller.mageStats.castSpeed))
            {

            }
        }
    }
}
