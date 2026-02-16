using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] Camera playerCamera;

    void Update()
    {
        transform.rotation = playerCamera.transform.rotation;
    }
}