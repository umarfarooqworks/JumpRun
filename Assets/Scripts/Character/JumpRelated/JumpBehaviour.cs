using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBehaviour : MonoBehaviour
{
    public SurroundCheck groundCheck;
    public float jumpForce = 20;
    public float gravity = -9.81f;
    public float gravityScale = 5;
    [SerializeField]
    float velocity;
    [SerializeField]
    public float MaxFallVelocity = -40;
    public event Action<float> onPlayerJump = delegate { };
    void Update()
    {
        velocity += gravity * gravityScale * Time.deltaTime;

        if (velocity < MaxFallVelocity)
            velocity = MaxFallVelocity;

        if (groundCheck.isGrounded && velocity < 0) // check for ground
        {
            velocity = 0;
            jump();
        }
        
        if(!groundCheck.isGrounded && velocity >0 && groundCheck.isHittingCeiling) // check for ceiling
        {
            velocity *= -1;
        }
        transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
    }

    void jump()
    {
        velocity = getUpdatedJumpVelocity();
        onPlayerJump.Invoke(velocity);
    }

    float getUpdatedJumpVelocity()
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, 0.2f, Vector3.down, out hit, Mathf.Infinity))
        { 
            if(hit.transform.GetComponent<IBouncy>() != null)
            {
                return hit.transform.GetComponent<IBouncy>().getBounceStrength();
            }
        }
        return 0;
    }

}
