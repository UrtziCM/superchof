using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public bool gamePaused = false;

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

    public GameObject currentInteractror { get; set; }

    public void GameStart()
    {
        if (PlayerPrefs.GetInt("tutorial")==0)
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
        //Score
        //End

    }

    private void Tutorial()
    {
        //Llama a la generacion de inicio que es el tutorial
        PlayerPrefs.SetInt("tutorial", 1);
    }

    private void SaveData()
    {
        PlayerPrefs.Save();
    }
}
