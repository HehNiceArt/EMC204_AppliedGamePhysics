using UnityEngine;

public class SkyboxRotation : MonoBehaviour
{
    Material skybox;
    private void Start()
    {
        skybox = RenderSettings.skybox;
    }
    private void Update()
    {
        skybox.SetFloat("_Rotation", Time.time * 0.4f);
    }
}