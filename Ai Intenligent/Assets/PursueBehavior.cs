using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursueBehavior : Steering
{
    public Transform target;
    public float maxprediction;
    public override SteeringData GetSteering(SteeringBehaviorBase steeringbase)
    {
        SteeringData steeringData = new SteeringData();

        Vector3 direction = target.position - transform.position;
        float distance = direction.magnitude;
        float speedagent = GetComponent<Rigidbody>().velocity.magnitude;

        float prediction;
        if(speedagent <= distance / maxprediction)
        {
            prediction = maxprediction;
        }
        else
        {
            prediction = distance / speedagent;
        }
        

        Vector3 futurePosition = target.position + (target.GetComponent<Rigidbody>().velocity * prediction);
        steeringData.linear = Vector3.Normalize(futurePosition - transform.position);
        steeringData.linear *= steeringbase.maxAcceleration;

        return steeringData;
    }
}
