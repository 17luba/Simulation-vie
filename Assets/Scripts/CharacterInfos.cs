using UnityEngine;

public class CharacterInfos : MonoBehaviour
{
    [SerializeField] private float money = 500.0f;

    private UserInterface ui;

    private void Start()
    {
        ui = UserInterface.instence;
    }

    private void Update()
    {
        ui.setMoney(money);

        if(Input.GetKeyDown(KeyCode.M))
        {
            AddMoney(50);
        }
    }

    public void AddMoney(float value)
    {
        money += value;
    }
}
