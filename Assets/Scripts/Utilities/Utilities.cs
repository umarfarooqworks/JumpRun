using UnityEngine;

public static class Utilities
{
    public static float DistanceCheck(Transform A, Transform B)
    {
        return Vector3.Distance(A.position, B.position);
    }

    public static float DistanceCheckIgnoreYAxis(Transform origin, Transform target)
    {
        Vector3 originVector = origin.position;
        originVector.y = 0;

        Vector3 targetVector = target.position;
        targetVector.y = 0;

        return Vector3.Distance(originVector, targetVector);
    }
    public static float DistanceCheckIgnoreYAxis(Transform origin, Vector3 target)
    {
        Vector3 originVector = origin.position;
        originVector.y = 0;

        Vector3 targetVector = target;
        targetVector.y = 0;

        return Vector3.Distance(originVector, targetVector);
    }



    public static float DirCheckIgnoreYAxis(Transform origin, Transform target) // 1 = in front, -1 = back, 
    {
        Vector3 originVector = origin.position;
        originVector.y = 0;

        Vector3 targetVector = target.position;
        targetVector.y = 0;


        var heading = targetVector - originVector;
        heading.Normalize();
        return Vector3.Dot(heading, origin.forward);
    }

    public static float AngleCheck(Transform origin, Transform target)
    {
        float angle = Vector3.Angle(origin.transform.forward, target.position - origin.position);
        return Mathf.Abs(angle);
    }
}
