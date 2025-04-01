using UnityEngine;

public class CharacterMotor : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 12.0f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.3f;
    [SerializeField] private LayerMask groundMask;

    private bool isGrounded;
    private Vector3 velocity;

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
