using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInput
{
    event Action<bool> TouchPressed;
    bool IsTouchPressed();
    float GetXRotation();
}
