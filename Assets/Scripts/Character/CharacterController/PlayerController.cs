using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameEnums;

public class PlayerController : CharacterControllerBase
{
    [Space(20)]
    [Header("Player Extention")]

    public Transform GroundDetector;
    public Transform GroundDetectorBase;

    // Update is called once per frame
    void Update()
    {
        base.Update();
        UpdateGroundDetector();
        CheckIfLevelFail();
    }

    void UpdateGroundDetector()
    {
        float distance = Vector3.Distance(GroundDetector.position, SurroundCheck.getGroundHitPoint());
        GroundDetector.transform.localScale = new Vector3(GroundDetector.transform.localScale.x, distance / 2, GroundDetector.transform.localScale.z);
        GroundDetectorBase.position = SurroundCheck.getGroundHitPoint();
    }
    void CheckIfLevelFail()
    {
        if (base.CheckLevellFail())
        {
            GameController.OnGameFail();
        }
    }

    public override void OnJump(float jumpVelocity)
    {
        base.OnJump(jumpVelocity);
        if (base.checkIfFinalPlatformReached())
        {
            Debug.Log("Player completed the race");
            GameController.instance.OnGameComplete();
        }
    }
}
