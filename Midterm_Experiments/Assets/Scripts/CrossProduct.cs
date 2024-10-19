using UnityEditor;
using UnityEngine;

public class CrossProduct : MonoBehaviour
{
    public Transform target;
    private void Update()
    {
        Vector3 targetDir = (target.position - transform.position).normalized;
        Vector3 cross = Vector3.Cross(transform.position, targetDir);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Rotate(cross, 5f * Time.deltaTime);
        }

    }
    void OnDrawGizmos()
    {
        Vector3 headPos = transform.position;
        Vector3 lookDir = transform.forward;

        void DrawRay(Vector3 p, Vector3 dir) => Handles.DrawAAPolyLine(p, p + dir);
        if (Physics.Raycast(headPos, transform.forward, out RaycastHit hit))
        {
            Vector3 hitPos = hit.point;
            Vector3 up = hit.normal;
            Vector3 right = Vector3.Cross(up, lookDir).normalized;
            Vector3 forward = Vector3.Cross(right, up);

            Handles.color = Color.white;
            Handles.DrawAAPolyLine(headPos, hitPos);
            Handles.color = Color.green;
            Handles.DrawAAPolyLine(hitPos, up);
            Handles.color = Color.red;
            Handles.DrawAAPolyLine(hitPos, right);
            Handles.color = Color.cyan;
            Handles.DrawAAPolyLine(hitPos, forward);
        }
        else
        {
            Handles.color = Color.red;
            DrawRay(headPos, lookDir);
        }
    }
}