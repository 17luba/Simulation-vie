using UnityEngine;

public class InteractableDoor : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private bool isOpen;

    public bool IsOpen => isOpen;

    private void Start()
    {
       animator.SetBool("isOpen", isOpen);
    }

    public void Use()
    {
        isOpen = !isOpen;
        animator.SetBool("isOpen", isOpen);
    }

    public void Open()
    {
        isOpen = true;
        animator.SetBool("isOpen", isOpen);
    }

    public void Close()
    {
        isOpen = false;
        animator.SetBool("isOpen", isOpen);
    }
}
