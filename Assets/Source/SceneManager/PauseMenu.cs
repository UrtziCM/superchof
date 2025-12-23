using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;

    private bool isPaused;

    void Start()
    {
        pauseCanvas.SetActive(false);
        isPaused = false;
    }

    void Update()
    {
        Debug.Log("isPaused at Update start: " + isPaused);

        if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            Debug.Log("Resume Game");
            Debug.Log("isPaused before: " + isPaused);
            isPaused = false;
            pauseCanvas.SetActive(false);
            Time.timeScale = 1f;
        }else if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            Debug.Log("Pause Game");
            Debug.Log("isPaused before: " + isPaused);
            isPaused = true;
            pauseCanvas.SetActive(true);
            Time.timeScale = 0f;
        }

        Debug.Log("isPaused at Update end: " + isPaused);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Debug.Log("isPaused from Button: " + isPaused);
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("Resume Game from Button");
    }
}
