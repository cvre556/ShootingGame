using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections; 

public class PlayerHeart : MonoBehaviour
{
    public int hp = 3;
    public Text hpText;
    private Renderer[] renderers;
    private bool isBlinking = false;

    private void Start()
    {
        UpdateHpUI();

        
        renderers = GetComponentsInChildren<Renderer>();
    }

    public void TakeDamage(int damage)
    {
        if (isBlinking) return; 

        hp -= damage;
        UpdateHpUI();

        if (hp <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(BlinkEffect());
        }
    }

    void UpdateHpUI()
    {
        if (hpText != null)
        {
            hpText.text = "HP: " + hp.ToString();
        }
    }

    IEnumerator BlinkEffect()
    {
        isBlinking = true;

        float blinkDuration = 1f;
        float blinkInterval = 0.2f;
        float timer = 0f;

        while (timer < blinkDuration)
        {
            SetRenderersVisible(false);
            yield return new WaitForSeconds(blinkInterval);
            SetRenderersVisible(true);
            yield return new WaitForSeconds(blinkInterval);
            timer += blinkInterval * 2;
        }

        SetRenderersVisible(true);
        isBlinking = false;
    }

    void SetRenderersVisible(bool visible)
    {
        foreach (Renderer r in renderers)
        {
            r.enabled = visible;
        }
    }
}
