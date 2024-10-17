using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    [SerializeField] LayerMask attractionLayer;
    public float gravity = 9.81f;
    [SerializeField] float radius = 10;
    public List<Collider> AttractedObjects = new List<Collider>();
    public Transform attractorTransform;
    private void Awake()
    {
        attractorTransform = GetComponent<Transform>();
    }
    private void Update()
    {

    }
    void SetAttractedObjects()
    {
        AttractedObjects = Physics.OverlapSphere(attractorTransform.position, radius, attractionLayer).ToList();
    }
    void AttractObjects()
    {
        for (int i = 0; i < AttractedObjects.Count; i++)
        {
            AttractedObjects[i].GetComponent<GravityAttractable>().Attract(this);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}