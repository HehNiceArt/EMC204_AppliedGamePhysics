using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Vectors2D : MonoBehaviour
{
    [SerializeField] GameObject a, b;
    [Range(0, 4)]
    public float offset = 1f;
    public float abDist;
    public float distDist;
    public float lengthOrDistance;
    public Vector2 dirToPointNormalize;
    [SerializeField] bool normalized, magnitude, distance;

    private void OnDrawGizmos()
    {
        if (normalized)
        {
            Vector2 pt = transform.position;
            Vector2 normalizedPT = pt.normalized;
            //Vector2 dirToPt = pt / pt.magnitude;
            //dirToPointNormalize = dirToPt;
            dirToPointNormalize = normalizedPT;
            Gizmos.DrawLine(Vector2.zero, normalizedPT);
        }
        if (magnitude)
        {
            Vector2 pt = transform.position;
            //Full length of the vector
            float length = pt.magnitude;
            lengthOrDistance = length;
            Gizmos.DrawLine(Vector2.zero, pt);
        }
        if (distance)
        {
            Vector2 pt = a.transform.position;
            Vector2 tg = b.transform.position;

            #region Distance 
            float distUsingDist = Vector2.Distance(pt, tg);
            float distUsingMagn = (pt - tg).magnitude;
            distDist = distUsingDist;
            abDist = distUsingMagn;
            //Gizmos.DrawLine(tg, pt);
            #endregion

            Vector2 aToB = tg - pt;
            Vector2 aToBDir = aToB.normalized;
            Gizmos.DrawLine(pt, pt + aToBDir);
            //Vector2 midpoint = (pt + tg) / 2;
            //Vector2 offsetVector = aToBDir * offset;
            //Gizmos.DrawSphere(pt + offsetVector, 0.1f);
        }
    }
}
