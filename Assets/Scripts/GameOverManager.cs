using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI CurrentScoreText;
    public TextMeshProUGUI BestScoreText;

    void Start()
    {
        int currentScore = PlayerPrefs.GetInt("CurrentScore", 0);
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);

        CurrentScoreText.text = "Current Score : " + currentScore;
        BestScoreText.text = "Best Score : " + bestScore;
    }

    public void OnRestartButton()
    {
        SceneManager.LoadScene("GameScene");
    }
}
