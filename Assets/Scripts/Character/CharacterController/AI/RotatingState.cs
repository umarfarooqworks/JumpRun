using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameEnums;

public class RotatingState : AIBase
{

    public override void OnEnter()
    {
        base.OnEnter();
        float rot = Random.Range(0.3f, 0.6f);
        AIController.AIInput.setAIRotate(0.3f);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (isTargetInFront(0.99f))
        {
            AIController.ChangeState(AIStates.Jumping);
        }
    }

    public override void OnExit()
    {
        base.OnExit();
        AIController.AIInput.setAIRotate(0f);
    }

}
