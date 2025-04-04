using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string sceneToLoad = "Game";
    [SerializeField] private TextMeshProUGUI versinText;

    private void Start()
    {
        versinText.text = Application.version;
    }

    public void Play()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
