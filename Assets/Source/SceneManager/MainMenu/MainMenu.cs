using TMPro;
using UnityEditor.Analytics;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private TMP_Text maxScoreText;
    [SerializeField]
    private GameObject HPCanvas;
    [SerializeField]
    private GameObject ScoreCanvas;

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
        HPCanvas.SetActive(false);
        ScoreCanvas.SetActive(false);
    }

    public void Play()
    {
        mainMenuCanvas.SetActive(false);
        HPCanvas.SetActive(true);
        ScoreCanvas.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
