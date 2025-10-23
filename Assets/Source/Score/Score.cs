using UnityEngine;

public class Score
{
    public int currentScore = 0;
    [SerializeField] public GameObject player;
    [SerializeField] private int points = 4;

    public void AddPoints()
    {
        currentScore += points;
    }

    public bool IsHighScore()
    {
        if (currentScore > GameManager.Instance.maxSaveScore)
        {
            GameManager.Instance.maxSaveScore = currentScore;
            return true;
        }
        return false;
    }
}
