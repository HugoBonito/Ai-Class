using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBarge : Task
{
    private string doorName;

    public DoorBarge(string door)
    {
        doorName = door;
    }

    public override TaskStatus Run(AgentBehaviorTree agent, WorldManager worldManager)
    {
        if (worldManager.IsDoorBlock(doorName))
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
