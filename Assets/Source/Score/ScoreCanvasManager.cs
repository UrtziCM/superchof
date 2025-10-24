using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreCanvasManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;

    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = GameManager.Instance.scoreManagerInstance;
    }

    void Update()
    {
        scoreText.text = scoreManager.currentScore + "";
    }
}
