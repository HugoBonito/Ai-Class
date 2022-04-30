using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentBehaviorTree : MonoBehaviour
{
    public WorldManager worldManager;
    private Task behaviorTree;

    void Start()
    {
        Task moveToRoomSequence1 = new Sequence();
        moveToRoomSequence1.AddChild(new DoorOpenCondition("MyDoor"));
        moveToRoomSequence1.AddChild(new MoveAction("RoomWaypoint"));

        Task moveToRoomSequence2 = new Sequence();
        moveToRoomSequence2.AddChild(new MoveAction("MyDoorWaypoint"));
        moveToRoomSequence2.AddChild(new OpenDoorAction("MyDoor"));
        moveToRoomSequence2.AddChild(new MoveAction("RoomWaypoint"));

        behaviorTree = new Selector();
        behaviorTree.AddChild(moveToRoomSequence1);
        behaviorTree.AddChild(moveToRoomSequence2);
        
    }

    private void Update()
    {
        if ((behaviorTree.status == TaskStatus.Running) || (behaviorTree.status == TaskStatus.None))
        {
            behaviorTree.Run(this, worldManager);
        }
    }

    public bool isAtDestination(NavMeshAgent agent)
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0)
                    return true;
            }
        }
        return false;
    }
}
