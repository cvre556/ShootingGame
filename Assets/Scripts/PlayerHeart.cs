using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PlayerHeart : MonoBehaviour
{
    public int hp = 3;
    public Text hpText;
    public float invincibleDuration = 1f;
    private bool isInvincible = false;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // 수정됨
        UpdateHpUI();
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible) return;

        hp -= damage;
        UpdateHpUI();

        if (hp <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(InvincibilityCoroutine());
        }
    }

    void UpdateHpUI()
    {
        if (hpText != null)
        {
            hpText.text = "HP: " + hp.ToString();
        }
    }


    IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;

        float elapsed = 0f;
        Color originalColor = spriteRenderer.color;

        while (elapsed < invincibleDuration)
        {
            Color c = spriteRenderer.color;
            c.a = (c.a == 1f) ? 0.3f : 1f;
            spriteRenderer.color = c;

            yield return new WaitForSeconds(0.1f);
            elapsed += 0.1f;
        }

        spriteRenderer.color = originalColor;
        isInvincible = false;
    }

}
