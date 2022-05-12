using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationBehaviour : MonoBehaviour
{
    [SerializeField]
    Animator anim;

    public void PlayFlipAnimation()
    {
        if(Random.Range(1, 20) % 2  == 0)
        {
            anim.SetTrigger("Flip");
        }
        else
        {
            anim.SetTrigger("FlipReverse");
        }
    }
    public void PlayFallAnimation()
    {
        anim.SetTrigger("Fall");
    }
    public void PlayBigJumpAnimation()
    {
        anim.SetTrigger("BigJump");
    }

}
