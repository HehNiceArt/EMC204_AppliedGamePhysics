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
    [SerializeField] GunShoot gun;

    bool isVisible = false;
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
        OnBecameInvisible();
    }
    private void OnBecameInvisible()
    {
        Vector3 outOfBounds = new Vector3(15, startPos.transform.position.y, 0);
        if (V3Equal(rb.transform.position, outOfBounds))
        {
            isVisible = false;
            StartCoroutine(ResetPosition());
        }

    }
    public bool V3Equal(Vector3 a, Vector3 b)
    {
        return Vector3.SqrMagnitude(a - b) < 0.0001;
    }
    IEnumerator ResetPosition()
    {
        while (!isVisible)
        {
            yield return new WaitForSeconds(ResetCooldown);
            isVisible = true;
            gun.cooldown = 0;
            gun.isFiring = false;
            ResetPlayerPosition();
        }
    }

    void ResetPlayerPosition()
    {
        if (isVisible)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            rb.transform.position = startPos.transform.position;
            Vector2 speed = new Vector2(playerSpeed, 0);
            rb.velocity = speed;
        }
    }
}

