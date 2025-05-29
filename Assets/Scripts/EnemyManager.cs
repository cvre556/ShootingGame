using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // ���� �ð�
    float currentTime;

    // ���� �ð�
    public float createTime = 1;

    // �ּ� �ð�
    float minTime = 1;


    // �ִ� �ð�
    float maxTime = 5;


    // �� ���� ����
    public GameObject enemyFactory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // �¾ �� ���� ���� �ð��� ����
        createTime = UnityEngine.Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        // �ð��� �帣�ٰ�
        currentTime += Time.deltaTime;

        // ���� ���� �ð��� ���� �ð��� �Ǹ�
        if (currentTime > createTime)
        {
            // �� ���忡�� ���� �����ϰ�
            GameObject enemy = Instantiate(enemyFactory);
            // ����ġ�� ���� ��� �ʹ�.
            enemy.transform.position = transform.position;

            // ���� �ð��� 0���� �ʱ�ȭ
            currentTime = 0;

            // �¾ �� ���� ���� �ð��� ����
            createTime = UnityEngine.Random.Range(minTime, maxTime);
        }

    }
}
