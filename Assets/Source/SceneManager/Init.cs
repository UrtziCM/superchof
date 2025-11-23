using UnityEngine;

public class Init : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<ViewSceneManager>().LoadScene("SampleScene");
        gameObject.GetComponent<ViewSceneManager>().LoadScene("MainMenu");
    }
}
