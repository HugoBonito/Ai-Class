using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UntilFailDecorator : Decorator
{
    public override TaskStatus Run(AgentBehaviorTree agent, WorldManager worldManager)
    {
        if(status == TaskStatus.None)
        {
            status = TaskStatus.Running;
        }

        TaskStatus childStatus = child.Run(agent, worldManager);
        if(childStatus == TaskStatus.Failure)
        {
            status = TaskStatus.Success;
        }
        return status;
    }
}
