using UnityEngine;

public class PlayerOrientation : MonoBehaviour
{
    Rigidbody rb;
    PlayerController playerController;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerController = GetComponent<PlayerController>();
    }
    private void Update()
    {
        RaycastHit hit;
        Vector3 down = -transform.up;
        if (Physics.Raycast(transform.position, down, out hit, 10))
        {
            Quaternion targetRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            rb.rotation = Quaternion.Lerp(rb.rotation, targetRotation, 10);
        }
    }
}
