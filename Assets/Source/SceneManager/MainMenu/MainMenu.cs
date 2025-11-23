using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private TMP_Text maxScoreText;

    ViewSceneManager viewSceneManager;
    private void Awake()
    {
        viewSceneManager = GameObject.Find("SceneManager").GetComponent<ViewSceneManager>();
    }
    private void Start()
    {
        Time.timeScale = 0.0f;

        maxScoreText.text = "Max Score: " + GameManager.Instance.maxSaveScore.ToString();
    }

    public void Play()
    {
        viewSceneManager.UnloadScene("MainMenu");
        Time.timeScale = 1.0f;
    }
}
