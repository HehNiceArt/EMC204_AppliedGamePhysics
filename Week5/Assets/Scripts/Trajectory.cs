using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject target;
    [SerializeField] float time = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            time += Time.deltaTime;
            SetVelocityTrajectory(rb, time, target.transform.position, transform.position);
        }
    }
    public void SetVelocityTrajectory(Rigidbody rb, float time, Vector2 targetPos, Vector2 initialPos)
    {
        Vector3 distance = targetPos - initialPos;
        rb.velocity = new Vector3(CalculateArcSpeedX(distance.x, 0, time), CalculateArcSpeed(distance.y, Physics.gravity.y, time), CalculateArcSpeedZ(time));
    }
    public float CalculateArcSpeed(float distance, float acceleration, float time)
    {
        return (distance - CalculateArcDistance(0, acceleration, time)) / time;
    }
    public float CalculateArcSpeedZ(float time)
    {
        float z = target.transform.position.z - transform.position.z;
        return z / time;
    }
    public float CalculateArcSpeedX(float distance, float acceleration, float time)
    {
        return distance / time;
    }
    public float CalculateArcDistance(float initialVelocity, float acceleration, float time)
    {
        return initialVelocity * time + 0.5f * acceleration * time * time;
    }

}
