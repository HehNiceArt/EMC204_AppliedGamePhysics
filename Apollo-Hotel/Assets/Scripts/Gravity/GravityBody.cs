using UnityEngine;

public class GravityBody : MonoBehaviour
{
    public GravityAttractor attractor;
    [HideInInspector] public Rigidbody rb;
    PlayerController playerController;
    private void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
        playerController = GetComponentInChildren<PlayerController>();
        rb.useGravity = false;
        attractor = FindAnyObjectByType<GravityAttractor>();
    }
    private void Update()
    {
        if (playerController.isStunned)
        {
            attractor.Attract(rb, false, true);
        }
        else
        {
            attractor.Attract(rb, false, false);
        }
    }
}