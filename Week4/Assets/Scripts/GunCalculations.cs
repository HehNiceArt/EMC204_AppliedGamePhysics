using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class GunCalculations : MonoBehaviour
{
    [SerializeField] float cutoff = 45f;
    [SerializeField] Vector3 fixedDirection = new Vector3(0, -1, 0);

    void Update()
    {
        TrajectoryArea(fixedDirection);
    }

    bool TrajectoryArea(Vector3 toTargetArea)
    {
        float downDirection = Vector3.Dot(toTargetArea.normalized, -transform.up);
        float downAngle = Mathf.Acos(downDirection) * Mathf.Rad2Deg;
        return downAngle < cutoff;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 direction = (fixedDirection - transform.forward).normalized;

        Gizmos.DrawLine(transform.position, fixedDirection);

        float angleStep = 10f;
        for (float angle = -cutoff; angle <= cutoff; angle += angleStep)
        {
            Quaternion rotation = Quaternion.Euler(0, angle, 0);
            Vector3 point = transform.position + rotation * direction * 5f;
            Gizmos.DrawLine(transform.position, point);
        }
    }

}
