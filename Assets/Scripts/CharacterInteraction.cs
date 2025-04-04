using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float interactionDistance = 5.0f;
    [SerializeField] private LayerMask interactionLayer;
    [SerializeField] private MouseLock mouseLock;

    public MouseLock MouseLock => mouseLock;

    private UserInterface ui;
    private CharacterDiver driver;

    private void Start()
    {
        driver = GetComponent<CharacterDiver>();
        ui = UserInterface.instence; 
    }

    private void Update()
    {
        RaycastHit hit;
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

       
        if (Input.GetKeyDown(KeyCode.F) && driver.CurrentVehicule != null)
        {
            driver.ExitVehicule();
        }

        if (Physics.Raycast(ray, out hit, interactionDistance, interactionLayer))
        {
            switch (hit.collider.tag)
            {
                case "Interaction/Door":
                    InteractionDoor(hit);
                    break;

                case "Interaction/Switch":
                    InteractionSwitch(hit);
                    break;
                case "Interaction/Vehicule":
                    InteractionVehicule(hit);
                    break;
                default:
                    ui.HideAction();
                    break;
            }
        }
        else
        {
            ui.HideAction();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            mouseLock.SwitchView();
        }
    }

    private void InteractionVehicule(RaycastHit hit)
    {
        // Debug.Log("Interaction avec le véhicule");

        Vehicule vehicule = hit.collider.GetComponent<Vehicule>();

        if (driver.CurrentVehicule != null)
            return;

        if (vehicule == null)
        {
            Debug.LogError("Le script Vehicule est manquant", hit.collider);
            return;
        }
        // Debug.Log("Véhicule détecté : " + vehicule.VehiculeName);

        ui.ShowAction($"[F] Monter dans le véhicule ({vehicule.VehiculeName})");

        if (Input.GetKeyDown(KeyCode.F))
        {
            driver.EnterInVehicule(vehicule);
        }
    }

    private void InteractionSwitch(RaycastHit hit)
    {
        InteractableSwitch interactableSwitch = hit.collider.GetComponent<InteractableSwitch>();

        if (interactableSwitch == null)
        {
            Debug.LogError("Le script InteractableSwitch est manquant", hit.collider);
            return;
        }

        string action = interactableSwitch.IsOn ? "[F] Eteindre la lumière" : "[F] Allumer la lumière";

        ui.ShowAction(action);

        if (Input.GetKeyDown(KeyCode.F))
        {
            interactableSwitch.Use();
         }
    }

    private void InteractionDoor(RaycastHit hit)
    {
        InteractableDoor door = hit.collider.GetComponent<InteractableDoor>();

        if (door == null)
        {
            Debug.LogError("Le script InteractableDood est manquant", hit.collider);
            return;
        }

        string action = door.IsOpen ? "[F] Fermer la porte" : "[F] Ouvrir la porte";

        ui.ShowAction(action);

        if (Input.GetKeyDown(KeyCode.F))
        {
            door.Use();
   
        }
    }
}
