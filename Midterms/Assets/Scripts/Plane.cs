using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.UI;

public class Plane : MonoBehaviour
{
    [Range(0, 5f)]
    public float xAxis;
    [Range(0, 5f)]
    public float maxSpeed;
    public float timeToReachMaxSpeed;
    public float dragMultiplier;
    public Vector2 pitch;
    Rigidbody2D _self;
    float time;
    public float radius = 2f;
    public TextMeshProUGUI text;
    public Camera cam;
    void Start()
    {
        _self = GetComponent<Rigidbody2D>();
        xAxisMovement();
    }
    void Update()
    {
        cam.transform.position = _self.transform.position;
        cam.transform.position += new Vector3(0, 0, -1);
        if (Input.GetKey(KeyCode.Space))
        {
            time += Time.deltaTime;
            Accelerate();
        }
        else if (!Input.GetKey(KeyCode.Space))
        {
            xAxisMovement();
        }
        //tilt down 
        if (Input.GetKey(KeyCode.S))
        {
            Pitch(-pitch, dragMultiplier);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            Forward();
        }
        //tilt up
        if (Input.GetKey(KeyCode.W))
        {
            Pitch(pitch, dragMultiplier);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            Forward();
        }
        text.SetText("" + _self.velocity);
    }
    void xAxisMovement()
    {
        Vector2 xAxisMove = new Vector2(xAxis, 0);
        _self.velocity = xAxisMove;
    }
    Vector2 Accelerate()
    {
        float accelerate = Mathf.Lerp(xAxis, maxSpeed, time / timeToReachMaxSpeed);
        Vector2 accel = new Vector2(accelerate, 0);
        return _self.velocity = accel;
    }
    void Forward()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void Pitch(Vector2 pitch, float drag)
    {
        Vector2 origin = transform.position;
        Quaternion rot = Quaternion.Euler(origin.x, 0, pitch.y);
        transform.rotation = rot;
        if (pitch.y > 0)
        {
            _self.velocity += new Vector2(drag, 0);
            Debug.Log("awdw");
        }
        if (pitch.y < 0)
        {
            _self.velocity += new Vector2(-drag, 0);
            Debug.Log("awdw");
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(6, 0));
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
