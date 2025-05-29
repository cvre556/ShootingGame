using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text CurrentScoreUI;
    private int currentScore;

    public Text BestScoreUI;
    private int bestScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bestScore = PlayerPrefs.GetInt("Best Score", 0);

        BestScoreUI.text = "Best Score : " + bestScore;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetScore(int value)
    {
        currentScore++;

        CurrentScoreUI.text = "Current Score : " + currentScore;

        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            BestScoreUI.text = "Best Score : " + bestScore;

            PlayerPrefs.SetInt("Best Score", bestScore);
        }
    }


    public int GetScore()
    {
        return currentScore;
    }
}
