using UnityEngine;

public class test : MonoBehaviour
{
    public Transform other;

    void Update()
    {
        if (other)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 toOther = Vector3.Normalize(other.position - transform.position);
            Debug.Log(Vector3.Dot(forward, toOther));


            if (Vector3.Dot(forward, toOther) < 0)
            {
                Debug.Log("The other transform is behind me!");
            }
        }
    }
}