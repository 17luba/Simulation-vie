using UnityEngine;
using TMPro;

public class UserInterface : MonoBehaviour
{
    public static UserInterface instence;

    [SerializeField] private TextMeshProUGUI actionText;
    [SerializeField] private GameObject actionGo;

    private void Awake()
    {
        instence = this;
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
}
