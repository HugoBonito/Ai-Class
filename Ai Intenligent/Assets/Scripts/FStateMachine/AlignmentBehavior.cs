using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignmentBehavior : Steering
{

    private Transform[] agents;

    public float alignmentRadios;
    public override SteeringData GetSteering(SteeringBehaviorBase steeringbase)
    {
        SteeringData steeringData = new SteeringData();
        Vector3 sumDirections = Vector3.zero;
        int count = 0;
        foreach(Transform agent in agents)
        {
            if(Vector3.Distance(transform.position, agent.position) < alignmentRadios)
            {
                sumDirections += agent.GetComponent<Rigidbody>().velocity;
                count++;
            }
        }
        if(count > 0)
        {
            sumDirections /= count;

            steeringData.linear = Vector3.Normalize(sumDirections);
            steeringData.linear *= steeringbase.maxAcceleration;
        }

        return steeringData;
    }





    void Start()
    {
        SteeringBehaviorBase[] steeringAgents = FindObjectsOfType<SteeringBehaviorBase>();
        agents = new Transform[steeringAgents.Length - 1];
        int c = 0;
        foreach(SteeringBehaviorBase agent in steeringAgents)
        {
            if(agent.gameObject != gameObject)
            {
                agents[c] = agent.transform;
                c++;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, alignmentRadios);
    }
}
