using TMPro;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    [SerializeField]
    private TMP_Text maxScoreText;

    [SerializeField]
    private TMP_Text scoreText;

    ViewSceneManager viewSceneManager;

    private ScoreManager scoreManager;

    private void Awake()
    {
        viewSceneManager = GameObject.Find("SceneManager").GetComponent<ViewSceneManager>();
    }
    private void Start()
    {
        Time.timeScale = 0.0f;

        maxScoreText.text = "Max Score: " + GameManager.Instance.maxSaveScore.ToString();

        scoreManager = GameManager.Instance.scoreManagerInstance;

        scoreText.text = "Score: " + scoreManager.currentScore + "";
    }

    public void Replay()
    {
        viewSceneManager.UnloadScene("DeathMenu");
        viewSceneManager.UnloadScene("SampleScene");
        //Vuelve a cargar la escena del juego
        viewSceneManager.LoadScene("SampleScene");
        Time.timeScale = 1.0f;
    }
}
