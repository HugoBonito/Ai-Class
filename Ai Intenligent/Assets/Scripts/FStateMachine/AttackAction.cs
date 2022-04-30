using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Action/Attack")]
public class AttackAction : Action
{
    public override void Act(FiniteStateMachine fsm)
    {
        Debug.Log("Attack");
        fsm.GetAgent().Shoot();
    }
}
