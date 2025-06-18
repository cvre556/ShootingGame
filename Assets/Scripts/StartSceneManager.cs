using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    // 게임 시작 버튼 기능
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    // 최고 점수 초기화 버튼 기능
    public void OnClickResetBestScore()
    {
        PlayerPrefs.SetInt("BestScore", 0);
        PlayerPrefs.Save();
        Debug.Log("Best Score 초기화 완료");
    }
}