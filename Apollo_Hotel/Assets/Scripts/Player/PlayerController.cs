using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public float jumpForce;
    [SerializeField, Range(0f, 10f)] float jumpHeight = 2f;
    [SerializeField, Range(0, 5)] int maxJumps = 0;
    Rigidbody rb;
    Vector3 upAxis;
    bool onGround = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 gravity = CustomGravity.GetGravity(transform.position);
        rb.AddForce(gravity, ForceMode.Acceleration);
        float rotationInput = Input.GetAxis("Horizontal");
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, rotationInput * playerSpeed * Time.deltaTime, 0));
    }
    private void FixedUpdate()
    {
        Vector3 gravity = CustomGravity.GetGravity(transform.position, out upAxis);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpForward(gravity);
        }
    }
    void JumpForward(Vector3 gravity)
    {
        rb.AddForce(transform.forward * jumpForce, ForceMode.Impulse);
    }
}
