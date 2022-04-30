using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/State")]
public class State : ScriptableObject
{
    [SerializeField]
    private Action entryAction;
    [SerializeField]
    private Action[] stateAction;
    [SerializeField]
    private Action exitAction;
    [SerializeField]
    private Transition[] transitions;


    public Action[] GetStateActions()
    {
        return stateAction;
    }
    public Transition[] GetTransitions()
    {
        return transitions;
    }
    public Action GetEntryAction()
    {
        return entryAction;
    }
    public Action GetExitAction()
    {
        return exitAction;
    }


}
