using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public float initialVelocity = 1;
    public float maxSpeed;
    public float timeToReachMaxSpeed;
    public float dragMultiplier;
    public float angleTilt;
    public Transform other;
    public float time;
    public Camera cam;
    float timer;
    public TextMeshProUGUI text;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        cam.transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        if (Input.GetKey(KeyCode.Space))
        {
            MaxSpeedCalc();
        }
        else
        {
            rb.velocity = new Vector2(initialVelocity, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (PlaneAngle(angleTilt) > 0)
            {
                Quaternion target = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angleTilt);
                rb.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime);
                DragVelocity(dragMultiplier);
            }
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (PlaneAngle(-angleTilt) < 0)
            {
                Quaternion target = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -angleTilt);
                rb.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime);
                DragVelocity(-dragMultiplier);
            }
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        text.SetText(rb.velocity.x + "");
    }
    float PlaneAngle(float planeRot)
    {
        Vector3 head = new Vector2(other.position.x, other.position.y + planeRot);
        Vector2 toTargetNormalized = Vector3.Normalize(head - transform.position);
        float dot = Vector2.Dot(transform.up, toTargetNormalized);
        return dot;
    }
    private void MaxSpeedCalc()
    {
        float acceleration = Mathf.Lerp(initialVelocity, maxSpeed, timer / timeToReachMaxSpeed);
        rb.velocity = new Vector2(acceleration, 0);
    }
    void DragVelocity(float drag)
    {
        rb.velocity += new Vector2(drag, drag);
    }
}