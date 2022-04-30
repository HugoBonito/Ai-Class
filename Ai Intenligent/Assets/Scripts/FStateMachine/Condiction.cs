using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Condiction : ScriptableObject
{
    public abstract bool Test(FiniteStateMachine fsm);
}
