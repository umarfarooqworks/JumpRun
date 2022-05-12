using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameEnums;

public class AIController : CharacterControllerBase
{
    public Transform[] Targets;
    public int CurrentTarget = 0;

    public AIInputHandler AIInput;

    [Header("AI Extention")]
    [Space(20)]
    public AIStates CurrentState;
    bool hasFinishedRace = false;

    public AIBase[] States;
    AIBase currentState;

    private new void Start()
    {
        base.Start();
        ChangeState(AIStates.Rotating);
    }
    private new void OnDestroy()
    {
        base.OnDestroy();
    }

    private new void Update()
    {
        if (hasFinishedRace)
            return;

        base.Update();
        currentState?.OnUpdate();
    }

    void OnStateChange(AIBase state)
    {
        if (state == null)
            return;

        if (currentState != null)
        {
            currentState.OnExit();
            currentState.gameObject.SetActive(false);
        }

        currentState = state;
        CurrentState = currentState.State;
        currentState.gameObject.SetActive(true);

        currentState.OnEnter();
    }

    AIBase GetState(AIStates state)
    {
        foreach(AIBase x in States)
        {
            if(x.State == state)
            {
                return x;
            }
        }
        return null;
    }

    public void ChangeState(AIStates state)
    {
        OnStateChange(GetState(state));
    }
    public void UpdateCurrentTarget()
    {
        CurrentTarget++;
        if(CurrentTarget >= Targets.Length)
        {
            OnReachedFinalCheckPoint();
        }
    }

    public Transform GetCurrentTarget()
    {
        return Targets[CurrentTarget];
    }

    void OnReachedFinalCheckPoint()
    {
        hasFinishedRace = true;
    }

    public override void OnJump(float jumpVelocity)
    {
        base.OnJump(jumpVelocity);
        if (base.checkIfFinalPlatformReached())
        {
            Debug.Log("AI completed the race");
        }
    }
}
