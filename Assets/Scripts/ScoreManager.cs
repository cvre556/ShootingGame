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
        currentScore = 0; 

        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        BestScoreUI.text = "Best Score : " + bestScore;
        CurrentScoreUI.text = "Current Score : 0";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetScore(int value)
    {
        currentScore += value;

        CurrentScoreUI.text = "Current Score : " + currentScore;

        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            BestScoreUI.text = "Best Score : " + bestScore;

            PlayerPrefs.SetInt("Best Score", bestScore);
            PlayerPrefs.Save();
        }
    }


    public int GetScore()
    {
        return currentScore;
    }
}
