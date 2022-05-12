using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameEnums;

public class CharacterControllerBase : MonoBehaviour
{
    [Header("Base")]

    public GameController GameController;

    public PlayerStates State;
    public CharacterAnimationBehaviour CharacterAnimationBehaviour;
    public SurroundCheck SurroundCheck;
    public JumpBehaviour JumpBehaviour;

    public Transform StickMan;
    [SerializeField]
    float distance;
    // Start is called before the first frame update
    protected void Start()
    {
        JumpBehaviour.onPlayerJump += OnJump;
    }
    protected void OnDestroy()
    {
        JumpBehaviour.onPlayerJump -= OnJump;
    }


    protected void Update()
    {
        StickMan.localPosition = Vector3.Lerp(StickMan.localPosition, Vector3.zero, Time.time);
    }

    void ChangeState(PlayerStates S)
    {
        switch (S)
        {
            case PlayerStates.Falling:
                CharacterAnimationBehaviour.PlayFallAnimation();
                break;
            case PlayerStates.Flip:
                CharacterAnimationBehaviour.PlayFlipAnimation();
                break;
            case PlayerStates.BigJump:
                CharacterAnimationBehaviour.PlayBigJumpAnimation();
                break;
        }
    }


    public virtual void OnJump(float jumpVelocity)
    {
        if (GameController.instance.State != GameStates.InGame)
            return;

        {
            if (jumpVelocity <= GameConstants.NormalJump)
                ChangeState(PlayerStates.Flip);
            else
                ChangeState(PlayerStates.BigJump);
        }
    }
    protected bool CheckLevellFail()
    {
        if (StickMan.position.y < GameConstants.LevelFailDepth)
        {
            return true;
        }
        return false;
    }

    protected bool checkIfFinalPlatformReached()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity))
        {
            if (hit.transform.GetComponent<FinalPlatform>())
            {
                return true;
            }
        }
        return false;
    }



}
