using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float interactionDistance = 5.0f;
    [SerializeField] private LayerMask interactionLayer;

    private UserInterface ui;

    private void Start()
    {
        ui = UserInterface.instence; 
    }

    private void Update()
    {
        RaycastHit hit;
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

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
                default:
                    ui.HideAction();
                    break;
            }
        }
        else
        {
            ui.HideAction();
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
