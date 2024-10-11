using UnityEngine;

public class VelocityThing : MonoBehaviour
{

    public Vector3 initialVelocity = Vector3.right;
    Vector3 velocity = Vector3.right;
    public Vector3 acceleration = Vector3.zero;
    Rigidbody rb;
    public float time;
    private void Awake()
    {
        velocity = initialVelocity;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        //velocity += acceleration * Time.deltaTime;
        time += Time.deltaTime;
        Vector3 velMetersPerFrame = velocity * time;
        rb.velocity = velMetersPerFrame;

        //relative
        Quaternion rotAdd = Quaternion.AngleAxis(90f, Vector3.up);
        //absolutes
        Quaternion rot = Quaternion.LookRotation(transform.forward, Vector3.up);
        //add rotation
        Quaternion noot = rotAdd * rot;
        //subtract rotaton
        Quaternion noots = Quaternion.Inverse(rotAdd) * rot;

    }
}