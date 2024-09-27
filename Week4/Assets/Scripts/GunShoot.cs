using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : GunCalculations
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float speed;
    private void Update()
    {
        Shoot();
    }
    private void FixedUpdate()
    {
        TrajectoryArea();
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.SetActive(true);
            Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
            bulletRB.velocity = new Vector2(0, -speed);
        }
    }
}
