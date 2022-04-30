using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAction : Task
{
    private string destination;

    public MoveAction(string dest)
    {
        destination = dest;
    }

    public override TaskStatus Run(AgentBehaviorTree agent, WorldManager worldManager)
    {
        NavMeshAgent navMeshAgent = agent.GetComponent<NavMeshAgent>();
        Vector3 destinationPosition = worldManager.GetWaypointPosition(destination);
        if (status == TaskStatus.None)
        {
            navMeshAgent.SetDestination(destinationPosition);
            status = TaskStatus.Running;
        }
        else if (agent.isAtDestination(navMeshAgent))
        {
            status = TaskStatus.Success;
        }
        return status;
    }
    
}
