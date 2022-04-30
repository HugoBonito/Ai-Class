using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Action/Recover")]
public class RecoverAction : Action
{

    public override void Act(FiniteStateMachine fsm)
    {
        Debug.Log("Recover");
        
        
            fsm.GetAgent().Recover();
        if (fsm.GetAgent().isAtDestination())
        {
            fsm.GetAgent().RecoverEnergy();
        }

    }

}
