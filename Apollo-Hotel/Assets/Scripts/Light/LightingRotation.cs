using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingRotation : MonoBehaviour
{
    [SerializeField] Light myLight;
    Quaternion targetRotation;
    void Start()
    {
        targetRotation = transform.rotation;
        myLight = GetComponent<Light>();
    }

    void Update()
    {
        targetRotation = Quaternion.Euler(0f, transform.eulerAngles.y + 1000f * Time.deltaTime, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime);
    }
}
