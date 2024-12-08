using UnityEngine;

public enum SurfaceTypes
{
    Sphere,
    Plane
}
public class GravityAttractor : MonoBehaviour
{
    public SurfaceTypes surfaceTypes;
    public float gravity = 9.81f;
    private SphereCollider gravitySphere;
    [SerializeField] float gravitySphereRadius = 20f;

    private void Awake()
    {
        if (surfaceTypes == SurfaceTypes.Sphere)
        {
            gravitySphere = gameObject.AddComponent<SphereCollider>();
            gravitySphere.isTrigger = true;
            gravitySphere.radius = gravitySphereRadius;
        }
        else if (surfaceTypes == SurfaceTypes.Plane)
        {
            return;
        }
    }

    public void Attract(Rigidbody rb, bool isJumping = false, bool isStunned = false)
    {
        if (surfaceTypes == SurfaceTypes.Sphere)
        {
            rb.useGravity = false;
            Vector3 up = (transform.position - rb.position).normalized;
            float attractionStrength = isJumping ? gravity * 0.5f : gravity;
            rb.AddForce(up * attractionStrength, ForceMode.Acceleration);
        }
        else if (surfaceTypes == SurfaceTypes.Plane && !isStunned)
        {
            float attractionStrength = isJumping ? gravity * 0.5f : gravity;
            Vector3 down = -transform.up;
            rb.AddForce(down * attractionStrength, ForceMode.Acceleration);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            Attract(rb);
        }
    }
}
