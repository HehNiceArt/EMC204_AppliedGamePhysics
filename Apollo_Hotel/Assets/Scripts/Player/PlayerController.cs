using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public float jumpForce;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float rotationInput = Input.GetAxis("Horizontal");
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, rotationInput * playerSpeed * Time.deltaTime, 0));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpForward();
        }
    }
    void JumpForward()
    {
        rb.AddForce(transform.forward * jumpForce, ForceMode.Impulse);
    }
}
