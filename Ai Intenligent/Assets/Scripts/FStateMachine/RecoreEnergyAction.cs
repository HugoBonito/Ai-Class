using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Action/RecoverEnergy")]
public class RecoreEnergyAction : Action
{
    public override void Act(FiniteStateMachine fsm)
    {
        Debug.Log("Recover Energy");

        if (fsm.GetAgent().isAtDestination())
        {
            fsm.GetAgent().RecoverEnergy();
        }

    }
}
