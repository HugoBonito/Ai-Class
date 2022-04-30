using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekBehaviour : Steering
{
    public Transform target;
    public override SteeringData GetSteering(SteeringBehaviorBase steeringbase)
    {
        SteeringData steeringData = new SteeringData();
        steeringData.linear = Vector3.Normalize(target.position - transform.position);
        steeringData.linear *= steeringbase.maxAcceleration;
        return steeringData;

    }
}
