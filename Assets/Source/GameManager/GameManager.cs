using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

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
        boardGenerator = GetComponent<BoardGenerator>();

        for (int i = 0; i < 20; i++)
        {
            boardGenerator.GenerateRow();
        }

        maxSaveScore = PlayerPrefs.GetInt("Score");
        if (PlayerPrefs.GetInt("tutorial") == 0)
        {
            needTutorial = true;
        }
        else
        {
            needTutorial = false;
        }


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
            //Generacion normall
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
        if(scoreManagerInstance.IsHighScore())
        {
            //Pantalla de nuevo record
            SaveData();
        }
        //End
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
