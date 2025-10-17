using UnityEngine;

public class Score : MonoBehaviour
{
    public int currentScore = 0;
    [SerializeField] public GameObject player;
    [SerializeField] private int points = 4;

    public void AddPoints()
    {
        currentScore += points;
    }
}
