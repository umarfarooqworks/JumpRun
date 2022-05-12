using System;
using UnityEngine;

public class PlayerInputHandler : InputHandlerBase
{
    void Update()
    {
        if(GameController.instance.State == GameEnums.GameStates.InGame)
        {
            touchPressState = Input.GetMouseButton(0);
            x_Rotation = Input.GetAxis("Mouse X");
        }
    }
}
