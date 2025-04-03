using UnityEngine;

public class CarController : Vehicule
{
    [SerializeField] private float motorTorque = 800.0f;
    [SerializeField] private float brakeTorque = 5000.0f;
    [SerializeField] private float steerAngle = 40.0f;
    [SerializeField] private Rigidbody body;
    [SerializeField] private Wheel[] wheels;
    [SerializeField] private Transform centerOfMass;
    [SerializeField] private float timeToReverse = 0.2f;

    private float forwardSpeed;
    private bool isReversing;
    private float reverseTime;

    private void Awake()
    {
        body.centerOfMass = centerOfMass.localPosition;
    }

    private void FixedUpdate()
    {
        forwardSpeed = transform.InverseTransformDirection(body.velocity).z * 3.6f;

        if (hasControl)
        {
            float torque = Mathf.Clamp01(vertical) * motorTorque;
            float brake = vertical < 0f ? -vertical * brakeTorque : 0f;

            if (isReversing)
            {
                if (forwardSpeed > 1f && vertical > 0)
                {
                    isReversing = false;
                }else if (forwardSpeed > -0.1f && reverseTime == 0f && vertical > 0f)
                {
                    reverseTime = Time.timeSinceLevelLoad + timeToReverse;
                }else if (reverseTime < Time.timeSinceLevelLoad && reverseTime != 0f)
                {
                    isReversing = false;
                    reverseTime = 0f;
                }

                torque = Mathf.Clamp01(-vertical) * -motorTorque;
                brake = vertical > 0f ? vertical : 0f;
            }
            else
            {
                if (reverseTime == 0f && vertical < 0f && forwardSpeed < 0.1f)
                {
                    reverseTime = Time.timeSinceLevelLoad + timeToReverse;
                }else if (reverseTime < Time.timeSinceLevelLoad && reverseTime != 0f)
                {
                    isReversing = true;
                    reverseTime = 0f;
                }
            }

            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i].PhysicsUpdate(steerAngle * horizontal, torque, brake);
            }
        }
    }

    public override void Update()
    {
        base.Update();

        for (int i = 0; i < wheels.Length; i++)
        {
            wheels[i].VisualUpdate();
        }
    }

}

[System.Serializable]

public class Wheel
{
    public Transform transform;
    public WheelCollider collider;


    public float steeringFactor;
    public float brakeFactor = 1f;
    public float motorFactor = 1f;

    public void VisualUpdate()
    {
        collider.GetWorldPose(out Vector3 position, out Quaternion rotation);
        transform.position = position;
        transform.rotation = rotation;
    }

    public void PhysicsUpdate(float steerAngle, float motorTorque, float brakeTorque)
    {
        collider.steerAngle = steerAngle * steeringFactor;
        collider.motorTorque = motorTorque * motorFactor;
        collider.brakeTorque = brakeTorque * brakeFactor;
    }
}
