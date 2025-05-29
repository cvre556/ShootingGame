using UnityEngine;

public class Background : MonoBehaviour
{
    // ��� ��Ƽ���� 
    public Material bgMaterail;

    // ��ũ�� �ӵ�
    public float scrollSpeed = 0.2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ���� �ʿ�
        Vector2 direction = Vector2.up;

        bgMaterail.mainTextureOffset += direction * scrollSpeed * Time.deltaTime;
    }
}
