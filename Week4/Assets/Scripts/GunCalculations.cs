using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class GunCalculations : MonoBehaviour
{
    [SerializeField] public float cutoff = 45f;

    public Quaternion TrajectoryArea()
    {
        Vector3 toTargetArea = new Vector3(0, -1, 0);
        float downDirection = Vector3.Dot(toTargetArea.normalized, -transform.up);
        float downAngle = Mathf.Acos(downDirection) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, downAngle, 0);

        return rotation;
    }
    private void OnDrawGizmos()
    {
        Vector3 toTargetArea = new Vector3(0, -1, 0);
        Gizmos.color = Color.red;
        Vector3 direction = (toTargetArea - transform.forward).normalized;

        Gizmos.DrawLine(transform.position, toTargetArea);

        float angleStep = 10f;
        for (float angle = -cutoff; angle <= cutoff; angle += angleStep)
        {
            Quaternion rotation = Quaternion.Euler(0, angle, 0);
            Vector3 point = transform.position + rotation * direction * 5f;
            Gizmos.DrawLine(transform.position, point);
        }
    }

}
