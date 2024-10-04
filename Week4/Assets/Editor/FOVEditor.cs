using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GunCalculations))]
public class FOVEditor : Editor
{
    void OnSceneGUI()
    {
        GunCalculations fov = (GunCalculations)target;
        if (fov == null) return;

        Handles.color = Color.white;


        // viweAngle, 0 , viewAngle
        // viewAngler, viewAngle
        Vector3 viewAngleA = fov.DirectionFromAngle(-fov.viewAngle / 2, true);
        Vector3 viewAngleB = fov.DirectionFromAngle(fov.viewAngle / 2, true);

        Handles.DrawLine(fov.transform.position, fov.transform.position + new Vector3(viewAngleA.x, viewAngleA.z, 0) * fov.viewRadius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + new Vector3(viewAngleB.x, viewAngleB.z, 0) * fov.viewRadius);
    }
}