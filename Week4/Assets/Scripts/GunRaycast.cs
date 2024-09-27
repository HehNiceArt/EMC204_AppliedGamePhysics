using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;

public class GunRaycast : MonoBehaviour
{
    [SerializeField] private float raycastDistance;
    [SerializeField] GameObject targetArea;

    private void FixedUpdate()
    {
        RaycasttoTarget();
    }

    void RaycasttoTarget()
    {
        Vector3 direction = targetArea.transform.position - transform.position;
        float distance = direction.magnitude;

        Debug.DrawRay(transform.position, direction, Color.black);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -direction.normalized, distance);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Vector3 direction = targetArea.transform.position - transform.position;

        Debug.DrawRay(transform.position, direction, Color.white);
    }
}