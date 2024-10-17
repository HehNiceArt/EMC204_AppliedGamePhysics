using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        var camForward = Camera.main.transform.forward;
        camForward.y = 0;
        var camRight = Camera.main.transform.right;
        camRight.y = 0;

        Vector3 movementVector = (camForward * Input.GetAxisRaw("Vertical") + camRight * Input.GetAxisRaw("Horizontal")).normalized * playerSpeed;
        characterController.SimpleMove(movementVector);
    }
}
