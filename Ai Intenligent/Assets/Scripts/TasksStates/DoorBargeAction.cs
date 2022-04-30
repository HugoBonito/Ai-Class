using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBargeAction : Task
{
    private string doorName;

    public DoorBargeAction(string door)
    {
        doorName = door;
    }

    public override TaskStatus Run(AgentBehaviorTree agent, WorldManager worldManager)
    {
        worldManager.OpenDoor(doorName);
        status = TaskStatus.Failure;
        return status;
    }
}
