using TMPro;
using UnityEditor.Analytics;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private TMP_Text maxScoreText;

    [SerializeField]
    private GameObject mainMenuCanvas;

    private static bool EnterGame = true;

    private void Start()
    {
        maxScoreText.text = "Max Score: " + GameManager.Instance.maxSaveScore.ToString();

        if (EnterGame)
        {
            EnterGame = false;
            ShowMenu();
        }
        else
        {
            mainMenuCanvas.SetActive(false);
        }
    }

    public void ShowMenu()
    {
        mainMenuCanvas.SetActive(true);
    }

    public void Play()
    {
        mainMenuCanvas.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
