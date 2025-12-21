using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    [SerializeField]
    private TMP_Text maxScoreText;

    [SerializeField]
    private TMP_Text scoreText;

    [SerializeField]
    private GameObject deathCanvas;

    private ScoreManager scoreManager;

    private void Start()
    {
        deathCanvas.SetActive(false);
    }
    private void OnEnable()
    {
        maxScoreText.text = "Max Score: " + GameManager.Instance.maxSaveScore.ToString();

        scoreManager = GameManager.Instance.scoreManagerInstance;

        scoreText.text = "Score: " + scoreManager.currentScore + "";
    }

    public void Replay()
    {
        deathCanvas.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void DeathQuit()
    {
        Application.Quit();
    }
}
