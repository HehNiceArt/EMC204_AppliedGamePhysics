using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 15;
    public float jumpForce = 10f;
    public float jumpHeight = 10f;
    public float stunAmount = 2;
    public bool isStunned = false;
    public bool isGrounded;
    public SurfaceTypes surfaceTypes;
    public GravityAttractor attractor;
    Rigidbody rb;
    float horizontalInput;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isStunned) return;
        horizontalInput = Input.GetAxisRaw("Horizontal");
        if (!isStunned)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                Jump();
            }
        }
    }
    private void FixedUpdate()
    {
        if (!isStunned && horizontalInput != 0 && isGrounded)
        {
            if (surfaceTypes == SurfaceTypes.Sphere)
            {
                float rotationAmount = horizontalInput * moveSpeed * Time.fixedDeltaTime;
                transform.Rotate(0, rotationAmount, 0);
            }
            else if (surfaceTypes == SurfaceTypes.Plane)
            {
                float rotationAmount = horizontalInput * 2 * moveSpeed * Time.fixedDeltaTime;
                transform.Rotate(0, rotationAmount, 0);
            }
        }
    }
    void Jump()
    {
        if (surfaceTypes == SurfaceTypes.Sphere)
        {
            isGrounded = false;
            jumpForce = 5;
            jumpHeight = 10;
            horizontalInput = 0;
            Vector3 gravityUp = (transform.position - attractor.transform.position).normalized;
            Vector3 jumpDirection = gravityUp * jumpHeight + transform.forward * jumpForce;
            rb.velocity = jumpDirection;
        }
        else if (surfaceTypes == SurfaceTypes.Plane)
        {
            isGrounded = false;
            jumpForce = 3;
            jumpHeight = 5;
            horizontalInput = 0;
            Vector3 jumpDir = Vector3.up * jumpHeight + transform.forward * jumpHeight;
            rb.AddForce(jumpDir, ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            attractor = other.gameObject.GetComponent<GravityAttractor>();
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(StunPlayer(stunAmount));
        }
        if (other.gameObject.CompareTag("Void"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }
    }
    IEnumerator StunPlayer(float duration)
    {
        isGrounded = false;
        isStunned = true;
        yield return new WaitForSeconds(duration);
        isStunned = false;
    }
}