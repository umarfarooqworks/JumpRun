using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInputHandler : InputHandlerBase
{
    public void setAIRotate(float x_rot)
    {
        base.x_Rotation = x_rot;
    }
    public void setAIMoveForward(bool b)
    {
        base.touchPressState = b;
    }
}