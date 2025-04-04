using UnityEngine;

public class CharacterDiver : MonoBehaviour
{
    private CharacterInteraction interaction;
    private Vehicule currentVehicule;

    public Vehicule CurrentVehicule => currentVehicule;

    private void Awake()
    {
        interaction = GetComponent<CharacterInteraction>();
    }

    public void EnterInVehicule(Vehicule vehicule)
    {
        Debug.Log("Tentative d'entrée dans le véhicule");

        if (currentVehicule != null)
        {
            Debug.LogWarning("Le personnage est déjà dans un véhicule", currentVehicule);
            return;
        }

        currentVehicule = vehicule;

        GetComponent<CharacterController>().enabled = false;
        GetComponent<CharacterMotor>().enabled = false;

        transform.position = currentVehicule.Seats[0].seat.position;
        transform.rotation = currentVehicule.Seats[0].seat.rotation;
        transform.SetParent(currentVehicule.Seats[0].seat);

        currentVehicule.SetControl(true);
        interaction.MouseLock.SetTarget(vehicule.CameraTarget);
    }

    public void ExitVehicule()
    {
        if (currentVehicule == null)
        {
            Debug.LogWarning("Le personnage n'est pas dans un véhicule");
            return;
        }

        transform.position = currentVehicule.Seats[0].exit.position;
        transform.rotation = currentVehicule.Seats[0].exit.rotation;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

        GetComponent<CharacterController>().enabled = true;
        GetComponent<CharacterMotor>().enabled = true;

        currentVehicule.SetControl(false);

        currentVehicule = null;
        
        interaction.MouseLock.SetTarget(null);
    }

}
