using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameEnums;

public class JumpingState : AIBase
{
    [SerializeField]
    float angle;

    bool moveToForwardState;
    bool moveToRotationState;
    public override void OnEnter()
    {
        base.OnEnter();
        moveToForwardState = false;
        moveToRotationState = false;

        AIController.JumpBehaviour.onPlayerJump += OnJump;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();        
        if (isTargetInFront())
        {
            moveToForwardState = true;
            Debug.Log("Move Forward");
        }
        else
        {
            moveToRotationState = true;
            Debug.Log("Rotate");
        }
    }

    void OnJump(float jumpStrength)
    {
        if(moveToForwardState)
        {
            AIController.ChangeState(AIStates.MovingForward);
        }
        else if(moveToRotationState)
        {
            AIController.ChangeState(AIStates.Rotating);
        }
    }

    public override void OnExit()
    {
        base.OnExit();
        AIController.JumpBehaviour.onPlayerJump -= OnJump;
    }



}
