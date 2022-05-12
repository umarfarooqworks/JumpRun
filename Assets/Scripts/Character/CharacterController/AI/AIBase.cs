using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameEnums;

public class AIBase : MonoBehaviour, IAIBase
{
    [Header("Base")]
    public AIStates State;
    public AIController AIController;
    float angleToTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OnEnter()
    {
    }

    public virtual void OnExit()
    {
    }

    public virtual void OnUpdate()
    {
    }

    protected bool isTargetInFront()
    {
        angleToTarget = Utilities.DirCheckIgnoreYAxis(AIController.transform, AIController.GetCurrentTarget());
        if (angleToTarget > 0.98f)
            return true;
        else return false;
    }
    protected bool isTargetInFront(float min)
    {
        angleToTarget = Utilities.DirCheckIgnoreYAxis(AIController.transform, AIController.GetCurrentTarget());
        if (angleToTarget > min)
            return true;
        else return false;
    }
}
