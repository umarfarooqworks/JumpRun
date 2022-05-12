using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRotationScript : RotationScript
{

    public override void Update()
    {
        Rotate();
    }

    void Rotate()
    {
            transform.RotateAround(transform.position,
                                            Vector3.up,
                                            base.InputProvider.GetXRotation() * speed);
    }
}
