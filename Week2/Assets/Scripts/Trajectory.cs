using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    public Transform YTarget;
     Rigidbody2D rb;
    public float time;

    Transform Player;
    float gravity = -9.81f;
    float upwardVelocity;
    float horizontalVelocity;

    [SerializeField]float speed, distance;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        upwardVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * (YTarget.position.y - transform.position.y));

        distance = YTarget.position.x - transform.position.x;
        //speed
        horizontalVelocity = distance / time;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(horizontalVelocity, upwardVelocity);
        }
    }
}
