using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenCondition : Task
{
    private string doorName;

    public DoorOpenCondition (string door)
    {
        doorName = door;
    }

    public override TaskStatus Run(AgentBehaviorTree agent, WorldManager worldManager)
    {
       if(worldManager.IsDoorOpen(doorName))
       {
            status = TaskStatus.Success;
       }
       else
       {
            status = TaskStatus.Failure;
       }
        return status;
    }
}
