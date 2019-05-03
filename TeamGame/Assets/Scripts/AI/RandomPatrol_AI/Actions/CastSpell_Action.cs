using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Stats/Actions/Cast Spell")]
public class CastSpell_Action : Action
{
    public override void Act(StateController controller)
    {
        CastSpell(controller);
        Debug.Log("In the fucking action");
    }

    private void CastSpell(StateController controller)
    {
        //RaycastHit hit;

        //Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * controller.mageStats.castRange, Color.red);

        if (Physics.SphereCast(controller.eyes.position, controller.mageStats.sphereLookRadius, controller.eyes.forward, out RaycastHit hit, controller.mageStats.castRange)
            && hit.collider.CompareTag("Player"))
        {
            if (controller.CheckTime(controller.mageStats.castSpeed))
            {
                float originalSpeed;
                originalSpeed = controller.mageStats.castSpeed;
                switch (controller.mageStats.type)
                {
                    case MageType.DARK:
                        controller.mageStats.castSpeed += Time.deltaTime;
                        if (controller.mageStats.castSpeed >= 5)
                        {
                            Debug.Log("The Cast Speed Timer Works");
                            controller.mageStats.castSpeed = originalSpeed;
                            controller.OnExitState();
                            Debug.Log(originalSpeed);
                        }
                        Debug.Log("I am dark");
                        break;
                    case MageType.FIRE:
                        Debug.Log("I am a Pyro");
                        break;
                    case MageType.HEALER:
                        Debug.Log("I am a Medic");
                        break;
                    case MageType.HOLY:
                        Debug.Log("I am Holy");
                        break;
                    case MageType.LIGHTNING:
                        Debug.Log("I am a Shock Expert");
                        break;
                }

            }
        }
    }
}
