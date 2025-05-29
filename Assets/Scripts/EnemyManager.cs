using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // 현재 시간
    float currentTime;

    // 일정 시간
    public float createTime = 1;

    // 최소 시간
    float minTime = 1;


    // 최대 시간
    float maxTime = 5;


    // 적 생산 공장
    public GameObject enemyFactory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 태어날 때 적의 생성 시간을 설정
        createTime = UnityEngine.Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        // 시간이 흐르다가
        currentTime += Time.deltaTime;

        // 만약 현재 시간이 일정 시간이 되면
        if (currentTime > createTime)
        {
            // 적 공장에서 적을 생성하고
            GameObject enemy = Instantiate(enemyFactory);
            // 내위치에 갖다 놀고 싶다.
            enemy.transform.position = transform.position;

            // 현재 시간을 0으로 초기화
            currentTime = 0;

            // 태어날 때 적의 생성 시간을 설정
            createTime = UnityEngine.Random.Range(minTime, maxTime);
        }

    }
}
