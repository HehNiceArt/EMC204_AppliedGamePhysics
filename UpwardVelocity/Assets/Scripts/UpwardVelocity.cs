using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpwardVelocity : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform target;
    public float predictedFallTime;
    public float actualFallTime;

    void Update()
    {

        float gravity = Mathf.Abs(Physics2D.gravity.y);
        //distance
        float height = target.position.y - transform.position.y;
        float initialVelocity = Mathf.Sqrt(2 * gravity * height);

        float time = height / initialVelocity;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Calculate initial velocity to reach the target

            rb.velocity = new Vector2(0, initialVelocity);

            // Calculate predicted fall time
            predictedFallTime = Mathf.Sqrt(2 * height / gravity);

            actualFallTime = 0.5f * gravity * (time * time);
        }
    }

}