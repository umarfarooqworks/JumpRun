using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    protected IInput InputProvider;

    [SerializeField]
    protected float speed;

    [SerializeField]
    float InjectedRotspeed;

    private void Start()
    {
        InputProvider = GetComponent<IInput>();
    }
    // Update is called once per frame
    public virtual void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        if (InputProvider.IsTouchPressed())
        {
            InjectedRotspeed = InputProvider.GetXRotation();
            transform.RotateAround(transform.position,
                                            Vector3.up,
                                            InputProvider.GetXRotation() * speed);
        }
    }
}
