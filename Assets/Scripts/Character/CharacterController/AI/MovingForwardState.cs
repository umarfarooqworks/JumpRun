using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameEnums;

public class MovingForwardState : AIBase
{
    [SerializeField]
    float distance;
    [SerializeField]
    float CurrentPlatformEdgedistance;
    bool isOnEdge = false;
    bool jumped = false;
    public override void OnEnter()
    {
        base.OnEnter();
        AIController.AIInput.setAIMoveForward(true);
        isOnEdge = false;
        jumped = false;
        AIController.JumpBehaviour.onPlayerJump += OnJump;
        groundRadius = 0;
        groundHitPoint = Vector3.zero;
        groundCenter = Vector3.zero;
        CurrentPlatformEdgedistance = 0;
        distance = 0;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if(!isOnEdge)
            chceckForEdge();

        if(isOnEdge && jumped)
            MoveForwardAndStopIfReachedTheTarget();
    }

    RaycastHit hit;
    Vector3 groundHitPoint;
    Vector3 groundCenter;

    [SerializeField]
    float groundRadius = 0;
    void chceckForEdge()
    {
        groundHitPoint = base.AIController.JumpBehaviour.groundCheck.getGroundHitPoint();

        if (Physics.SphereCast(AIController.transform.position, 0.2f, Vector3.down, out hit, Mathf.Infinity))
        {
            if (hit.transform.GetComponent<IBouncy>() != null)
            {
                groundRadius = hit.transform.localScale.x / 2;
                groundCenter = hit.transform.position;
            }
            else return;
        }
        else return;


        CurrentPlatformEdgedistance = Utilities.DistanceCheckIgnoreYAxis(base.AIController.transform, groundCenter);
        if (CurrentPlatformEdgedistance > (groundRadius-1))
        {
            isOnEdge = true;
            AIController.AIInput.setAIMoveForward(false);
            // this waits for next jump to trigger moving forward again!
        }
    }

    void OnJump(float jumpStrength)
    {
        if (isOnEdge)
        {
            jumped = true;
        }
    }

    void MoveForwardAndStopIfReachedTheTarget()
    {
        distance = Utilities.DistanceCheckIgnoreYAxis(AIController.GetCurrentTarget(), AIController.transform);
        if (distance > 3f)
        {
            AIController.AIInput.setAIMoveForward(true);
            Debug.Log("Moving Forward");
        }
        else if(distance <= 3f)
        {
            AIController.AIInput.setAIMoveForward(false);
            AIController.UpdateCurrentTarget();
            AIController.ChangeState(AIStates.Jumping);
            Debug.Log("Now Rotate and update CheckPoint!");
        }
    }

    public override void OnExit()
    {
        base.OnExit();
        AIController.JumpBehaviour.onPlayerJump -= OnJump;
        AIController.AIInput.setAIMoveForward(false);
    }

}
