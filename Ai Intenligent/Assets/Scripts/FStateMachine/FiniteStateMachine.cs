using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine : MonoBehaviour
{
    public State initialState;
    private State currentState;
    private AgentNavMesh agent;

    void Start()
    {
        currentState = initialState;
        agent = GetComponent<AgentNavMesh>();
    }

    public AgentNavMesh GetAgent()
    {
        return agent;
    }

    void Update()
    {
        Transition triggeredTransition = null;
        foreach (Transition transition in currentState.GetTransitions())
        {
            if (transition.IsTriggered(this))
            {
                triggeredTransition = transition;
                break;
            }
        }
        List<Action> actions = new List<Action>();
        if (triggeredTransition)
        {
            State targetState = triggeredTransition.GetTargetState();
            actions.Add(currentState.GetExitAction());
            actions.Add(triggeredTransition.GetAction());
            actions.Add(currentState.GetEntryAction());
            currentState = targetState;
        }
        else
        {
            foreach (Action action in currentState.GetStateActions())
            {
                actions.Add(action);
            }
        }
        foreach (Action action in actions)
        {
            if (action)
            {
                action.Act(this);
            }
        }
    }
}
