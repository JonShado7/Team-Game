using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Stat/Decisions/Cast Spell Decision")]
public class CastSpellDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        bool cast = CastDecision(controller);
        return cast;
    }
    private bool CastDecision(StateController controller)
    {
        if (controller.distance <= controller.mageStats.castRange)
        {
            Debug.Log("It is fucking operational");
            return true;
        }
        else
        {
            return false;
        }
    }

}
