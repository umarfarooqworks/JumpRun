using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBase : MonoBehaviour, IBouncy
{
    [SerializeField]
    float bounceStrength;
    public float getBounceStrength()
    {
        return bounceStrength;
    }
}
