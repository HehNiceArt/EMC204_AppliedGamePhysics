using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rbexp : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float dragCoefficient = 0.5f;
    [SerializeField] private float fluidDensity = 1.224f;
    [SerializeField] private float crossSectionalArea = 1f; //m^2
    [SerializeField] private Vector2 windForce = new Vector2(5f, 0f);
    [SerializeField] private float moveSpeed = 7f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveInput, 0) * moveSpeed;

        rb.AddForce(movement);

        if (rb.velocity.magnitude > 0)
        {
            //dragForce = -0.5f * C_{d} * Q * A * v^2 * v_hat
            //C_{d} = drag coefficient
            //Q = density of the fluid, here it's air
            //A = cross section area 
            //v^2 = Velocity of the object
            //v_hat = unit vector in the direction of the velocity
            Vector2 dragForce = -0.5f * dragCoefficient * fluidDensity * crossSectionalArea * rb.velocity.sqrMagnitude * rb.velocity.normalized;
            Debug.Log("Drag: " + dragForce);
            rb.AddForce(dragForce);
        }

        rb.AddForce(windForce);
        Debug.Log("Wind: " + windForce);

    }
}
