using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArriveBehavior : Steering
{
    public Transform target;
    public float stopRadius;
    public float slowRadius;

    public override SteeringData GetSteering(SteeringBehaviorBase steeringbase)
    {
        SteeringData steeringData = new SteeringData();
        Vector3 direction = target.position - transform.position;
        float distance = direction.magnitude;

        if(distance < stopRadius)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            return steeringData;
        }
        float speed;
        if( distance < slowRadius)
        {
            speed = steeringbase.maxAcceleration * (distance / slowRadius);
        }
        else
        {
            speed = steeringbase.maxAcceleration;
        }

        steeringData.linear = (direction.normalized * speed) - GetComponent<Rigidbody>().velocity;


        return steeringData;

    }
}
