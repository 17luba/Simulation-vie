using UnityEngine;
using UnityEngine.Events;

public class InteractableSwitch : MonoBehaviour
{
    [SerializeField] private UnityEvent switchOnEvent;
    [SerializeField] private UnityEvent switchOffEvent;

    [SerializeField] private bool isOn;

    public bool IsOn => isOn;


    private void Start()
    {
        if (isOn)
        {
            switchOnEvent?.Invoke();
        }
        else
        {
            switchOffEvent?.Invoke();
        }
    }

    public void Use()
    {
        isOn = !isOn;

        if (isOn)
        {
            switchOnEvent?.Invoke();
        }
        else
        {
            switchOffEvent?.Invoke();
        }
    }

    public void SwitchOn()
    {
        isOn = true;

        if (isOn)
        {
            switchOffEvent?.Invoke();
        }
        else
        {
            switchOnEvent?.Invoke();
        }
    }

    public void SwitchOff()
    {
        isOn = false;

        if (isOn)
        {
            switchOffEvent?.Invoke();
        }
        else
        {
            switchOnEvent?.Invoke();
        }
    }
}
