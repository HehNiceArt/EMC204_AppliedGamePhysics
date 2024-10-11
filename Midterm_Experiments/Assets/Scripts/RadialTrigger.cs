using UnityEditor;
using UnityEngine;

public class RadialTrigger : MonoBehaviour
{
    public Transform obj;
    [Range(0, 4)]
    public float radius = 1;
    private void OnDrawGizmos()
    {
        Vector2 origin = transform.position;
        Vector2 objPos = obj.position;

        //float dist = Vector2.Distance(objPos, origin);
        float dist = (objPos - origin).magnitude;

        bool isInside = dist <= radius;

        Handles.color = isInside ? Color.green : Color.red;
        Handles.DrawWireDisc(origin, Vector3.forward, radius);
    }
}