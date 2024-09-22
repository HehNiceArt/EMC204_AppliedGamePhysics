using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryScripts : MonoBehaviour
{
    [SerializeField] private float power = 5f;
    [SerializeField] private float clampDistance;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LineRenderer lr;
    private Vector2 dragStartPos;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))
        {
            Vector2 dragEndPosition =
            Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var direction = dragEndPosition - dragStartPos;
            var normalizedDirection = direction.normalized;
            var distance = Vector2.Distance(dragEndPosition, dragStartPos);
            distance = Mathf.Clamp(distance, 0, clampDistance);
            Vector2 _velocity = normalizedDirection * distance * power * -1;
            Vector2[] trajectory = Plot(rb, (Vector2)transform.position, _velocity,
            500);
            lr.positionCount = trajectory.Length;
            Vector3[] positions = new Vector3[trajectory.Length];
            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = trajectory[i];
            }
            lr.SetPositions(positions);
        }
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 dragEndPosition =
            Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var direction = dragEndPosition - dragStartPos;
            var normalizedDirection = direction.normalized;
            var distance = Vector2.Distance(dragEndPosition, dragStartPos);
            distance = Mathf.Clamp(distance, 0, clampDistance);
            Vector2 _velocity = normalizedDirection * distance * power * -1;
            rb.velocity = _velocity;
        }
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
