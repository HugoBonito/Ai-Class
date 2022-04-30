using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Condiction/HigthEnergy")]
public class HigthEnergyControl : Condiction
{
    [SerializeField]
    private bool negation;

    public override bool Test(FiniteStateMachine fsm)
    {
        Debug.Log(fsm.GetAgent().energy);
        if(fsm.GetAgent().energy > 0)
        {
            return !negation;
        }
        return negation;
    }
}
