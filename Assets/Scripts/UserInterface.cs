using UnityEngine;
using TMPro;

public class UserInterface : MonoBehaviour
{
    public static UserInterface instence;

    [SerializeField] private TextMeshProUGUI actionText;
    [SerializeField] private GameObject actionGo;
    [SerializeField] private TextMeshProUGUI moneyText;

    private void Awake()
    {
        instence = this;
    }

    private void Start()
    {
        setMoney(7500.32f);
    }

    public void ShowAction(string text)
    {
        actionGo.SetActive(true);
        actionText.text = text;
    }

    public void HideAction()
    {
        actionGo.SetActive(false);
    }

    public void setMoney(float money)
    {
        moneyText.text = money.ToString("C");
    }
}
