using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorAction : Task
{
    private string doorName;

    public OpenDoorAction(string door)
    {
        doorName = door;
    }

    public override TaskStatus Run (AgentBehaviorTree agent, WorldManager worldManager)
    {
        worldManager.OpenDoor(doorName);
        status = TaskStatus.Success;
        return status;
    }
}
