using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;
using UnityEngine.Rendering;

public class GunShoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject barrel;
    [SerializeField] float bulletSpeed;
    [SerializeField] float rotationSpeed;
    Vector3 localAngleA;
    Vector3 localAngleB;
    Vector3 newDirection;
    [SerializeField] public float cooldown;
    [SerializeField] public bool isFiring;
    private GameObject bulletPool;
    [SerializeField] public bool bulletinUse = false;

    GunCalculations gunCalculations;
    private void Start()
    {
        gunCalculations = GetComponent<GunCalculations>();
        if (gunCalculations == null) return;

        bulletPool = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bulletPool.SetActive(false);
    }
    private void Update()
    {
        if (bulletinUse && cooldown <= 0f)
        {
            bulletPool.SetActive(false);
            isFiring = false;
            bulletinUse = false;
        }
        if (!isFiring && cooldown <= 0f)
        {
            Shoot();
        }
        if (cooldown > 0f)
        {
            cooldown -= Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        GunRotation();
    }

    void GunRotation()
    {
        localAngleA = gunCalculations.DirectionFromAngle(-gunCalculations.viewAngle / 2, true);
        localAngleB = gunCalculations.DirectionFromAngle(gunCalculations.viewAngle / 2, true);

        float t = Mathf.PingPong(Time.time * rotationSpeed, 1);
        newDirection = Vector3.Lerp(return2DVector(localAngleA), return2DVector(localAngleB), t);
        barrel.transform.up = -newDirection;
    }

    Vector3 return2DVector(Vector3 viewAngle)
    {
        return new Vector3(viewAngle.x, viewAngle.z, 0);
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && cooldown <= 0f && !bulletinUse)
        {
            bulletPool.SetActive(true);
            bulletPool.transform.position = barrel.transform.position;
            bulletPool.transform.rotation = barrel.transform.rotation;
            Rigidbody2D bulletRB = bulletPool.GetComponent<Rigidbody2D>();
            Vector2 bulletDir = barrel.transform.up;
            bulletRB.velocity = bulletDir * -bulletSpeed;
            isFiring = true;
            cooldown = 5f;
            bulletinUse = true;
        }
    }
}
