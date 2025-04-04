using UnityEngine;

public class MouseLock : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 200f;
    [SerializeField] private Transform playerBody;

    [Header("Orbit Camera")]
    [SerializeField] private float distance = 5.0f;
    [SerializeField] private float xSpeed = 120.0f;
    [SerializeField] private float ySpeed = 120.0f;
    [SerializeField] private float yMinLimit = -20.0f;
    [SerializeField] private float yMaxLimit = 80.0f;
    [SerializeField] private float distanceMin = 5.0f;
    [SerializeField] private float distanceMax = 15.0f;

    private float orbitY;
    private float orbitX;
    private Transform target;
    private bool isOrbitalCamera;


    private float xRotation = 0.0f;
    private Vector3 localPosition;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        localPosition = transform.localPosition;
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    public void SwitchView()
    {
        isOrbitalCamera = !isOrbitalCamera;
    }

    private void Update()
    {
        if (isOrbitalCamera)
        {
            if (target == null)
            {
                isOrbitalCamera = false;
                return;
            }

            orbitX += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
            orbitY -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;

            orbitY = Utils.ClampAngle(orbitY, yMinLimit, yMaxLimit);

            Quaternion rotation = Quaternion.Euler(orbitY, orbitX, 0);

            distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5f, distanceMin, distanceMax);

            Vector3 negativeDistance = Vector3.forward * -distance;
            Vector3 targetPosition = rotation * negativeDistance + target.position;

            transform.position = targetPosition;
            transform.rotation = rotation;
        }
        else
        {
            transform.localPosition = localPosition;

            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
