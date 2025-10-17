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
        //if (primera prtida == true)
        //{
        //  Tutorial();
        //}
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
        //Ponemos una cuenta atras
        yield return new WaitForSeconds(3);
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
    }
}
