using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float time;
    [SerializeField] float initVel, finalVel;
    [SerializeField] float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionY;
    }
    void Update()
    {
        time += Time.deltaTime;
        AccelerationCalc();
        if (V3Compare(rb.velocity, new Vector3(finalVel, 0, finalVel)))
        {
            DeccelerationCalc();
        }
    }

    bool V3Compare(Vector3 a, Vector3 b)
    {
        return Vector3.SqrMagnitude(a - b) < 0.0001;
    }

    void AccelerationCalc()
    {
        Vector3 accel = Vector3.Lerp(new Vector3(initVel, 0, initVel), new Vector3(finalVel, 0, finalVel), time * speed);
        rb.velocity = accel;
    }

    void DeccelerationCalc()
    {
        float dec = (finalVel - initVel) / time;
        Vector3 deccel = new Vector3(dec, 0, dec);
        rb.velocity = deccel;
    }
}
