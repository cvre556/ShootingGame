using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    Vector3 dir;
    GameObject player;
    public float speed = 5;

    // 폭발 공장 
    public GameObject explosionFactory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int rndValue = UnityEngine.Random.Range(0, 10);

        if (rndValue <= 3)
        {
            GameObject target = GameObject.Find("Player");

            dir = target.transform.position - transform.position;

            dir.Normalize(); // 방향 크기를 1로 하고 싶을 때
        }
        else
        {
            dir = Vector3.down;
            //transform.position += dir * speed * Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //씬에서 잡을 때마나 현재 점수를 표시
        // 1. 씬에서 SceneManger 객체를 찾아온다
        GameObject smObject = GameObject.Find("ScoreManger");
        // 2. ScoreManager 게임 오브젝트를 얻어온다
        ScoreManager sm = smObject.GetComponent<ScoreManager>();
        // 3. ScoreManager 속성 값을 가져온다.
        // sm.currentScore++;
        sm.SetScore(sm.GetScore() + 1);

        GameObject explosion = Instantiate(explosionFactory);

        explosion.transform.position = transform.position;

        // 너 죽고
        Destroy(collision.gameObject);
        // 나 죽자
        Destroy(gameObject);

        /*
        if (sm.currentScore > sm.bestScore)
        {
            sm.bestScore = sm.currentScore;

            sm.BestScoreUI.text = "최고 점수 : " + sm.bestScore;

            PlayerPrefs.SetInt("Best Score", sm.bestScore);
        }
        */

    }

}
