
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHeart : MonoBehaviour
{
    int heart = 1;
    public bool isGameOver = false;

    void Update()
    {
        if (!isGameOver && (heart == 2 || heart == 1))
        {
            transform.Rotate(0, 0, 30 * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        heart--;


        if (heart == 0)
        {
            isGameOver = true;

            SceneManager.LoadScene("GameOverScene");
            Destroy(gameObject);
        }

    }
}
