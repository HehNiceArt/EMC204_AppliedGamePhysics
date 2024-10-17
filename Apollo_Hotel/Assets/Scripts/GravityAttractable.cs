using UnityEngine;

public class GravityAttractable : MonoBehaviour
{
    [SerializeField] private bool rotateToCenter = true;
    [SerializeField] private GravityAttractor currentAttractor;
    [SerializeField] private float gravityStrength = 100;

    Transform m_transform;
    Collider m_collider;
    Rigidbody m_rigdibody;

    private void Start()
    {
        m_transform = GetComponent<Transform>();
        m_collider = GetComponent<Collider>();
        m_rigdibody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (currentAttractor != null)
        {
            if (!currentAttractor.AttractedObjects.Contains(m_collider))
            {
                currentAttractor = null;
                return;
            }
            if (rotateToCenter) RotateToCenter();
        }
        else
        {
        }
    }

    public void Attract(GravityAttractor attractorObj)
    {
        Vector2 attractionDir = ((Vector3)attractorObj.attractorTransform.position - m_rigdibody.position).normalized;
        m_rigdibody.AddForce(attractionDir * -attractorObj.gravity * gravityStrength * Time.fixedDeltaTime);

        if (currentAttractor == null)
        {
            currentAttractor = attractorObj;
        }

    }

    void RotateToCenter()
    {
        if (currentAttractor != null)
        {
            Vector3 distanceVector = (Vector3)currentAttractor.attractorTransform.position - (Vector3)m_transform.position;
            float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;
            m_transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        }
    }
}