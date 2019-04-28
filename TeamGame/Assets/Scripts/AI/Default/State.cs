using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Stats/State")]
public class State : ScriptableObject
{
    public Action[] actions;
    public Transition[] transitions;

    public void UpdateState(StateController controller)
    {        
        DoActions(controller);
        CheckTransitions(controller);
    }
    private void DoActions(StateController controller)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Act(controller);
        }
    }

    private void CheckTransitions(StateController controller)
    {
        for (int i = 0; i < transitions.Length; i++)
        {
            bool decisionMade = transitions[i].decision.Decide(controller);
            if (decisionMade)
            {
                controller.TransitionState(transitions[i].trueState);
            }
            else
            {
                controller.TransitionState(transitions[i].falseState);
            }
        }
    }
}
