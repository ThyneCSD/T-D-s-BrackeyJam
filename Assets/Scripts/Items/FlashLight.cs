using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] GameObject flashLightLight;
    [SerializeField] Camera playerCamera;

    void Update()
    {
        transform.rotation = playerCamera.transform.rotation;
    }
}