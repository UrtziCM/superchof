using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject tilePrefab;

    private static GameManager instance;
    public bool gamePaused = false;
    private int maxSaveScore;
    private bool needTutorial;



    private Score ScoreManagerInstance;
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
        boardGenerator = new BoardGenerator(Vector3.zero + Vector3.left * 4, tilePrefab);
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
        if(IsHighScore())
        {
           //Pantalla de nuevo record
        }
        //End

    }

    private void Tutorial()
    {
        //Llama a la generacion de inicio que es el tutorial
        PlayerPrefs.SetInt("tutorial", 1);
    }

    private bool IsHighScore()
    {
        if (ScoreManagerInstance.currentScore > maxSaveScore)
        {
            maxSaveScore = ScoreManagerInstance.currentScore;
            return true;
        }
        return false;
    }

    public void AddScore()
    {
        ScoreManagerInstance.AddPoints();
    }
    private void SaveData()
    {
        PlayerPrefs.SetInt("Score", maxSaveScore);
        PlayerPrefs.Save();
    }
}
