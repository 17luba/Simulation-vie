using UnityEngine;

public class Vehicule : MonoBehaviour
{
    [SerializeField] private string vehiculeName = "New Vehicule";
    [SerializeField] private Seat[] seats;
    [SerializeField] private Transform cameraTarget;


    public string VehiculeName => vehiculeName;

    public Seat[] Seats => seats;
    public Transform CameraTarget => cameraTarget;

    protected float horizontal;
    protected float vertical;
    protected bool hasControl;

    public void SetControl(bool value)
    {
        hasControl = value;
    }

    public virtual void Update()
    {
        if (hasControl)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
        }
    }
}

[System.Serializable]

public class Seat
{
    public Transform seat;
    public Transform exit;
}
