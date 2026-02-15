using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float sprintMutiplier;

    public Transform orientation;

    private Rigidbody rb;
    private bool sprinting;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Movement();
        Sprinting();
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        moveDirection.y = 0f;

        rb.linearVelocity = new Vector3(moveDirection.x * moveSpeed, rb.linearVelocity.y, moveDirection.z * moveSpeed);
    }

    private void Sprinting()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed *= sprintMutiplier;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed /= sprintMutiplier;
        }
    }
}
