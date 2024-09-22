using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastExp : MonoBehaviour
{
    [SerializeField] private float rayLength;

    void Update()
    {
        //normalized, direction, magnitude, raycast

        if (Physics2D.Raycast(transform.position, new Vector2(0.707f, 0.707f), rayLength, 1 << LayerMask.NameToLayer("Floor")))
        {
            Debug.Log("Hit!");
        }
        else
        {
            Debug.Log("No Hit!");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + (new Vector3(.707f, .707f) * rayLength));
    }
}
