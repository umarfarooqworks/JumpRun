using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandlerBase : MonoBehaviour, IInput
{
    [SerializeField]
    protected bool touchPressState;
    [SerializeField]
    protected float x_Rotation;
    public event Action<bool> TouchPressed;

    public float GetXRotation()
    {
        return x_Rotation;
    }

    public bool IsTouchPressed()
    {
        return touchPressState;
    }

    //void Update()
    //{
    //    if (GameController.instance.State == GameEnums.GameStates.InGame)
    //    {
    //        touchPressState = Input.GetMouseButton(0);
    //        x_Rotation = Input.GetAxis("Mouse X");
    //    }
    //}
}
