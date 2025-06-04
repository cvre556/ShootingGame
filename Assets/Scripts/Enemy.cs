
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    // 폭발 공장 
    public GameObject explosionFactory;

    private Vector3 dir;

    void Start()
    {
        // 30% 확률로 플레이어 추적, 아니면 아래로 이동
        int rndValue = Random.Range(0, 10);
        if (rndValue <= 3)
        {
            GameObject target = GameObject.Find("Player");
            if (target != null)
            {
                dir = (target.transform.position - transform.position).normalized;
            }
            else
            {
                dir = Vector3.down; // 기본 이동 방향으로 설정
            }
        }

        dir = Vector3.down;

    }

    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //씬에서 잡을 때마나 현재 점수를 표시
        // 1. 씬에서 SceneManger 객체를 찾아온다\
        // 2. ScoreManager 게임 오브젝트를 얻어온다    
        // 3. ScoreManager 속성 값을 가져온다.
        GameObject smObject = GameObject.Find("ScoreManager");
        if (smObject != null)
        {
            ScoreManager sm = smObject.GetComponent<ScoreManager>();
            sm.SetScore(10);
        }

        // 폭발 이펙트 생성
        if (explosionFactory != null)
        {
            Instantiate(explosionFactory, transform.position, Quaternion.identity);
        }

        // 충돌한 오브젝트와 자신 제거
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
/*
       if (sm.currentScore > sm.bestScore)
       {
           sm.bestScore = sm.currentScore;

           sm.BestScoreUI.text = "최고 점수 : " + sm.bestScore;

           PlayerPrefs.SetInt("Best Score", sm.bestScore);
       }
*/