using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityBody : MonoBehaviour
{
    public GravityAttractor gravityAttractor;
    public LayerMask layerMask;
    public Rigidbody rb;
    private void Awake()
    {
        gravityAttractor = GameObject.FindGameObjectWithTag("Planet").GetComponent<GravityAttractor>();
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
    private void Update()
    {
    }
    private void FixedUpdate()
    {
        gravityAttractor.Attract(transform);
    }

    void RayRotation()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, layerMask))
        {
            Vector3 surfaceNormal = hit.normal;
            Debug.DrawLine(transform.position, surfaceNormal, Color.blue, Mathf.Infinity);

            transform.rotation = Quaternion.Euler(surfaceNormal.x, surfaceNormal.y, surfaceNormal.z);
        }
    }

}
