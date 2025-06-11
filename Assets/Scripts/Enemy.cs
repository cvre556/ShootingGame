using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    public GameObject explosionFactory;

    private Vector3 dir;

    void Start()
    {
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
                dir = Vector3.down;
            }
        }
        else
        {
            dir = Vector3.down;
        }
    }

    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void HandleExplosionAndScore()
    {
        GameObject smObject = GameObject.Find("ScoreManager");
        if (smObject != null)
        {
            ScoreManager sm = smObject.GetComponent<ScoreManager>();
            sm.SetScore(10);
        }

        if (explosionFactory != null)
        {
            Instantiate(explosionFactory, transform.position, Quaternion.identity);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 총알과 충돌한 경우만 처리
        if (collision.gameObject.CompareTag("Bullet"))
        {
            HandleExplosionAndScore();

            Destroy(collision.gameObject); // Bullet 제거
            Destroy(gameObject);           // Enemy 제거
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHeart player = other.GetComponent<PlayerHeart>();
            if (player != null)
            {
                player.TakeDamage(1);
            }

            HandleExplosionAndScore();
            Destroy(gameObject);
        }
        else if (other.CompareTag("Bullet"))
        {
            HandleExplosionAndScore();
            Destroy(other.gameObject); 
            Destroy(gameObject);      
        }
    }

}


//씬에서 잡을 때마나 현재 점수를 표시
// 1. 씬에서 SceneManger 객체를 찾아온다\
// 2. ScoreManager 게임 오브젝트를 얻어온다    
// 3. ScoreManager 속성 값을 가져온다.
/*
       if (sm.currentScore > sm.bestScore)
       {
           sm.bestScore = sm.currentScore;

           sm.BestScoreUI.text = "최고 점수 : " + sm.bestScore;

           PlayerPrefs.SetInt("Best Score", sm.bestScore);
       }
*/