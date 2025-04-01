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
            Debug.Log(hit.collider.tag);
        }
    }
}
