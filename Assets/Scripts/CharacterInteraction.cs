using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float interactionDistance = 5.0f;
    [SerializeField] private LayerMask interactionLayer;

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
            }
        }
    }

    private void InteractionDoor(RaycastHit hit)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            InteractableDoor door = hit.collider.GetComponent<InteractableDoor>();

            if (door != null)
            {
                door.Use();
            }
            else
            {
                Debug.LogError("Le script InteractableDood est manquant", hit.collider);
            }
        }

        Debug.Log($"Je regarde le gameobject {hit.collider.name}");
    }
}
