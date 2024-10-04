using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class GunCalculations : MonoBehaviour
{
    [SerializeField] public float viewRadius;
    [SerializeField] public float viewAngle;
    [SerializeField] public float cutoff = 45f;

    public Quaternion TrajectoryArea()
    {

        Vector3 toTargetArea = new Vector3(0, -1, 0);
        float downDirection = Vector3.Dot(toTargetArea.normalized, -transform.up);
        float downAngle = Mathf.Acos(downDirection) * Mathf.Rad2Deg;
        Debug.Log(downAngle);

        Quaternion rotation = Quaternion.Euler(0, downAngle, 0);

        return rotation;
    }
    public Vector3 DirectionFromAngle(float angleInDegrees)
    {
        return new Vector3(0, 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
