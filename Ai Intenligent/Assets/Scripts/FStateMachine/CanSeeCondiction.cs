using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Condiction/CanSee")]
public class CanSeeCondiction : Condiction
{
    [SerializeField]
    private bool negation;
    [SerializeField]
    private float viewAngle;
    [SerializeField]
    private float viewDistance;

    public override bool Test(FiniteStateMachine fsm)
    {
        Debug.Log("Test Can See");
        Transform target = fsm.GetAgent().target;
        Vector3 direction = target.position - fsm.transform.position;
        float distance = direction.magnitude;
        float angle = Vector3.Angle(direction.normalized, fsm.transform.forward);
        if ((angle < viewAngle) && (distance < viewDistance))
        {
            return !negation;
        }
        return negation;
    }
}
