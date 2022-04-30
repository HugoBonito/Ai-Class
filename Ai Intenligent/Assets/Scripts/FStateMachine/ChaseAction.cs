using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Action/Chase")]
public class ChaseAction : Action
{
    public override void Act(FiniteStateMachine fsm)
    {
        Debug.Log("Chase");
        if (fsm.GetAgent().isAtDestination())
        {
            Debug.Log("Go to target!");
            fsm.GetAgent().GoToTarget();
        }
    }
}
