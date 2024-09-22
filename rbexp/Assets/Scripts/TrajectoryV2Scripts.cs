
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TrajectoryV2Script : MonoBehaviour
{
    [SerializeField] private GameObject player, target;
    [SerializeField] private float time;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LineRenderer lr;
    [SerializeField] private float timer;
    private bool startTimer = false;
    public void Test()
    {
        SetVelocityTrajectory(rb, time, target.transform.position,
        player.transform.position);
        Vector2[] trajectory = Plot(rb, (Vector2)transform.position, rb.velocity,
        500);
        lr.positionCount = trajectory.Length;
        Vector3[] positions = new Vector3[trajectory.Length];
        for (int i = 0; i < positions.Length; i++)
        {
            positions[i] = trajectory[i];
        }
        lr.SetPositions(positions);
        timer = 0;
        startTimer = true;
    }
    private void Update()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;
        }
        if (Vector2.Distance(player.transform.position, target.transform.position)
        < .1)
            startTimer = false;
    }
    public void SetVelocityTrajectory(Rigidbody2D rb, float time, Vector2
    targetPos, Vector2 initialPos)
    {
        Vector2 distance = targetPos - initialPos;
        rb.velocity = new Vector3(CalculateArcSpeedX(distance.x, 0, time),
        CalculateArcSpeed(distance.y,
        Physics2D.gravity.y * rb.gravityScale, time), 0);
    }
    public Vector3 GetVelocityTrajectory(Rigidbody2D rb, float time, Vector2
    targetPos, Vector2 initialPos)
    {
        Vector2 distance = targetPos - initialPos;
        return new Vector3(CalculateArcSpeed(distance.x, 0, time),
        CalculateArcSpeed(distance.y,
        Physics2D.gravity.y * rb.gravityScale, time), 0);
    }
    public float CalculateArcSpeed(float distance, float acceleration, float time)
    {
        return (distance - CalculateArcDistance(0, acceleration, time)) / time;
    }
    public float CalculateArcSpeedX(float distance, float acceleration, float time)
    {
        return distance / time;
    }
    public float CalculateArcDistance(float initialVelocity, float acceleration,
    float time)
    {
        return initialVelocity * time + 0.5f * acceleration * time * time;
    }
    public Vector2[] Plot(Rigidbody2D rigidbody, Vector2 pos, Vector2 velocity, int
    steps)
    {
        Vector2[] results = new Vector2[steps];
        float timeStep = Time.fixedDeltaTime / Physics2D.velocityIterations;
        Vector2 gravityAccel = Physics2D.gravity * rigidbody.gravityScale *
        timeStep * timeStep;
        float drag = 1f - timeStep * rigidbody.drag;
        Vector2 moveStep = velocity * timeStep;
        for (int i = 0; i < steps; i++)
        {
            moveStep += gravityAccel;
            moveStep *= drag;
            pos += moveStep;
            results[i] = pos;
        }
        return results;
    }
}