using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text CurrentScoreUI;
    public Text BestScoreUI;

    private int currentScore;
    private int bestScore;

    void Start()
    {
        currentScore = 0;
        bestScore = PlayerPrefs.GetInt("BestScore", 0);

        CurrentScoreUI.text = "Current Score : 0";
        BestScoreUI.text = "Best Score : " + bestScore;
    }

    public void SetScore(int value)
    {
        currentScore += value;
        CurrentScoreUI.text = "Current Score : " + currentScore;

        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }

        PlayerPrefs.SetInt("CurrentScore", currentScore);
        PlayerPrefs.Save();

        BestScoreUI.text = "Best Score : " + bestScore;
    }

    public int GetScore()
    {
        return currentScore;
    }
}
