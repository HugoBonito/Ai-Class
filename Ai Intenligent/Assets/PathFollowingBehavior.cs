using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowingBehavior : Steering
{

    public PathLine path;

    private float currentParam = 0;
    private float futureParam = 0;
    public float pathOffset;

    public float maxprediction;
    public Transform target;

    public override SteeringData GetSteering(SteeringBehaviorBase steeringbase)
    {
        SteeringData steeringData = new SteeringData();
        Vector3 targetPosition;

        

        
        if (path.nodes.Length == 1)
        {
            targetPosition = path.nodes[0];
        }
        else
        {

            float speedagent = GetComponent<Rigidbody>().velocity.magnitude;
            float prediction;
            Vector3 direction = (transform.position + (transform.GetComponent<Rigidbody>().velocity * maxprediction)) - transform.position;
            float distance = direction.magnitude;

            

            
            if (speedagent <= distance / maxprediction)
            {
                prediction = maxprediction;
            }
            else
            {
                prediction = distance / speedagent;
            }
            //currentParam = path.GetParam(transform.position);
            //float targetParam = currentParam + pathOffset;
            Vector3 futurePosition = transform.position + (transform.GetComponent<Rigidbody>().velocity * prediction);
            futureParam = path.GetParam(futurePosition);
            float targetParam = futureParam + pathOffset;
            targetPosition = path.GetPosition(targetParam);

            Debug.DrawLine(futurePosition, targetPosition);

            steeringData.linear = Vector3.Normalize(targetPosition - transform.position);
            steeringData.linear *= steeringbase.maxAcceleration;
        }

        return steeringData;
    }
}
