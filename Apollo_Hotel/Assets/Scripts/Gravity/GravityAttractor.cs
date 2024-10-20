using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    public float gravity = -9.81f;

    public void Attract(Transform body)
    {
        Vector3 targetDirection = (body.position - transform.position).normalized;

        Vector3 closestPoint = transform.position + Vector3.Scale(targetDirection, transform.localScale / 2);
        Vector3 gravityDirection = (body.position - closestPoint).normalized;

        body.GetComponent<Rigidbody>().AddForce(gravityDirection * gravity);
    }
    private void OnDrawGizmos()
    {
    }
}