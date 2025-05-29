using UnityEngine;

public class Background : MonoBehaviour
{
    // 배경 머티리얼 
    public Material bgMaterail;

    // 스크롤 속도
    public float scrollSpeed = 0.2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 방향 필요
        Vector2 direction = Vector2.up;

        bgMaterail.mainTextureOffset += direction * scrollSpeed * Time.deltaTime;
    }
}
