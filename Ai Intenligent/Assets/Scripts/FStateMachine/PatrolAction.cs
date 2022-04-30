using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Action/Patrol")]
public class PatrolAction : Action
{
    public override void Act(FiniteStateMachine fsm)
    {
        Debug.Log("Patrol");
        if (fsm.GetAgent().isAtDestination())
        {
            fsm.GetAgent().GoToNextWaypoint();
        }
    }
}
