using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : GunCalculations
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed = 5f;
    private void Update()
    {
        Shoot();
    }
    private void FixedUpdate()
    {
        TrajectoryArea();
    }

    private void RotateGun()
    {
        Quaternion targetRotation = TrajectoryArea();
        float targetZAngle = targetRotation.eulerAngles.z;
        Quaternion currentRotation = transform.rotation;

        float clampedZAngle = Mathf.Clamp(targetZAngle, -cutoff, cutoff);
        // Debug.Log("Clamped Z Angle: " + clampedZAngle);
        float currentZAngle = currentRotation.eulerAngles.z;
        //Debug.Log("Current Z Angle: " + currentZAngle);
        float angleDifference = Mathf.DeltaAngle(currentZAngle, clampedZAngle);
        //Debug.Log("Angle Difference: " + angleDifference);
        Quaternion newTargetRotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y, currentZAngle + angleDifference);

        transform.rotation = Quaternion.RotateTowards(currentRotation, newTargetRotation, rotationSpeed * Time.deltaTime);
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
