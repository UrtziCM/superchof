using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject player;


    private static GameManager instance;
    public bool gamePaused = false;
    public int maxSaveScore;
    private bool needTutorial;
    private float maxForwardPos;


    public ScoreManager scoreManagerInstance = new();

    private BoardGenerator boardGenerator;

    [SerializeField]
    private GameObject deathMenuCanvas;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("Game manager is NULL");
            }
            return instance;
        }
    }
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;


        boardGenerator = GetComponent<BoardGenerator>();


        maxSaveScore = PlayerPrefs.GetInt("Score");
        if (PlayerPrefs.GetInt("tutorial") == 0)
        {
            needTutorial = true;
        }
        else
        {
            needTutorial = false;
        }
        GameStart();

    }
    public GameObject currentInteractror { get; set; }

    public void GameStart()
    {
        if (needTutorial)
        {
            Tutorial();
        }
        else
        {
            boardGenerator.GenerateStart();
        }
        
    }

    public void GameStop()
    {
        StartCoroutine(PausaMenu());
        gamePaused = true;
        Time.timeScale = 0f;
    }

    private IEnumerator PausaMenu()
    {
        while (gamePaused)
        {
            yield return null;
        }
        //Ponemos una cuenta atras del tiempo real
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1.0f;
    }

    public void GameEnd()
    {

        if (scoreManagerInstance.IsHighScore())
        {
            //Pantalla de nuevo record
            SaveData();
        }
        //End
        //SceneManager.LoadScene(0);

        deathMenuCanvas.SetActive(true);
        Debug.Log(deathMenuCanvas.activeSelf);
    }

    private bool IsMaxForward()
    {
        if (player.transform.position.z > maxForwardPos)
        {
            maxForwardPos = player.transform.position.z;
            return true;
        }
        return false;
    }

    private void Tutorial()
    {
        //Llama a la generacion de inicio que es el tutorial
        boardGenerator.GenerateStart(!needTutorial);
        PlayerPrefs.SetInt("tutorial", 1);
    }

    public void TryAddScore()
    {
        if (IsMaxForward())
        {
            scoreManagerInstance.AddPoints();
            boardGenerator.GenerateRandomRow();
        }
    }
    private void SaveData()
    {
        PlayerPrefs.SetInt("Score", maxSaveScore);
        PlayerPrefs.Save();
    }


}
