using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    public bool mouseNeeded = true;

    private void Start()
    {
        mouseNeeded = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (mouseNeeded == false)
        {
            return;
        }
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    public void UsingUI(bool uiUsed)
    {
        mouseNeeded = !uiUsed;

        Cursor.lockState = uiUsed ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = uiUsed;
    }

    //public void StoppedUI(bool uiUsed)
    //{
    //    mouseNeeded = true;
    //    Cursor.lockState = CursorLockMode.Locked;
    //    Cursor.visible = false;
    //}
}
