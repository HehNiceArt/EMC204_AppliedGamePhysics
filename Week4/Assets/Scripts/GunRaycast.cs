using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;

public class GunRaycast : MonoBehaviour
{
    [SerializeField] GameObject targetArea;
    [SerializeField] GameObject bullet;
    [SerializeField] LayerMask layerMask;
    [SerializeField] public float distance;
    [SerializeField] public float dir;

    private void Update()
    {
        bullet = GameObject.FindGameObjectWithTag("bullet");
        RaycastToBullet();

    }

    void RaycastToBullet()
    {
        Vector3 direction = targetArea.transform.position - bullet.transform.position;
        dir = Vector3.Distance(targetArea.transform.position, bullet.transform.position);
        distance = direction.magnitude;

        layerMask = LayerMask.GetMask("bullet");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction.normalized, distance, layerMask);
        Debug.DrawLine(targetArea.transform.position, bullet.transform.position, Color.red);
    }

}