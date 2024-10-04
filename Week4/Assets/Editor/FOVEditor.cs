using System.Collections;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GunCalculations))]
public class FOVEditor : Editor
{
    private void OnSceneGUI()
    {
        GunCalculations fov = (GunCalculations)target;
        Handles.color = Color.white;

        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.viewRadius);

    }
}
