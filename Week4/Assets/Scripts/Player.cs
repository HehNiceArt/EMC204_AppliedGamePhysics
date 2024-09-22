using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] GameObject startPos;
    [SerializeField] float playerSpeed = 5f;
    [SerializeField] float ResetCooldown = 3f;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.transform.position = startPos.transform.position;

        Vector2 speed = new Vector2(playerSpeed, 0);
        rb.velocity = speed;
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    void Update()
    {

    }
    private void OnBecameInvisible()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    IEnumerator ResetPosition()
    {
        while (true)
        {
            yield return new WaitForSeconds(ResetCooldown);
            ResetPlayerPosition();
        }
    }

    void ResetPlayerPosition()
    {
        rb.transform.position = startPos.transform.position;
    }
}

