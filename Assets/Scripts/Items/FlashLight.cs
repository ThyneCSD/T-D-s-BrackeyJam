using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] Light flashLightLight;
    [SerializeField] Camera playerCamera;

    void Update()
    {
        transform.rotation = playerCamera.transform.rotation;
    }
}