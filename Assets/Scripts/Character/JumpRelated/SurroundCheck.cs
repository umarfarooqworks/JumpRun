using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurroundCheck : MonoBehaviour
{
    public float distanceToCheck = 2.5f;
    public bool isGrounded;
    public bool isHittingCeiling;

    Vector3 groundHitPoint;
    Vector3 ceilHitPoint;

    RaycastHit hit;
    private void Update()
    {
        if (Physics.SphereCast(transform.position,0.2f, Vector3.down, out hit, Mathf.Infinity))
        {
            groundHitPoint = hit.point;
        }
        if (Physics.SphereCast(transform.position, 0.2f, Vector3.up, out hit, Mathf.Infinity))
        {
            ceilHitPoint = hit.point;
        }

        if (Vector3.Distance(transform.position, groundHitPoint) < distanceToCheck)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (Vector3.Distance(transform.position, ceilHitPoint) < distanceToCheck)
        {
            isHittingCeiling = true;
        }
        else
        {
            isHittingCeiling = false;
        }

    }

    public Vector3 getGroundHitPoint()
    {
        return groundHitPoint;
    }
    public Vector3 getCeilHitPoint()
    {
        return ceilHitPoint;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundHitPoint, 1f);
    }
}
