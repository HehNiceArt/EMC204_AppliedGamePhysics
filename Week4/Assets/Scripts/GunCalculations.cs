using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class GunCalculations : MonoBehaviour
{
    [SerializeField] public float viewRadius;
    [Range(0, 360)]
    [SerializeField] public float viewAngle;

    public Vector3 DirectionFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.z;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

}
