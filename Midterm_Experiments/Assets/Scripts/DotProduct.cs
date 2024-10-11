using UnityEngine;

public class DotProduct : MonoBehaviour
{
    public Transform target;
    [Range(0, 4)]
    public float offset = 1;
    public Vector2 directionToTarget;
    public Vector2 vector2Normalize;
    public float dot;

    private void OnDrawGizmos()
    {
        Vector2 origin = transform.position;
        Vector2 targ = target.position;

        Vector2 dist = targ - origin;
        Vector2 dirToTarget = dist.normalized;
        directionToTarget = dirToTarget;

        //Vector2 usingVector2 = Vector3.Normalize(dist);
        //vector2Normalize = usingVector2;

        dot = Vector2.Dot(transform.up, dirToTarget);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(origin, new Vector2(0, 1.5f) + origin);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(origin, origin + dirToTarget);
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(origin, offset);
    }
}