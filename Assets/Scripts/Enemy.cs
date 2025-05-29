using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    Vector3 dir;
    GameObject player;
    public float speed = 5;

    // ���� ���� 
    public GameObject explosionFactory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int rndValue = UnityEngine.Random.Range(0, 10);

        if (rndValue <= 3)
        {
            GameObject target = GameObject.Find("Player");

            dir = target.transform.position - transform.position;

            dir.Normalize(); // ���� ũ�⸦ 1�� �ϰ� ���� ��
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
        //������ ���� ������ ���� ������ ǥ��
        // 1. ������ SceneManger ��ü�� ã�ƿ´�
        GameObject smObject = GameObject.Find("ScoreManger");
        // 2. ScoreManager ���� ������Ʈ�� ���´�
        ScoreManager sm = smObject.GetComponent<ScoreManager>();
        // 3. ScoreManager �Ӽ� ���� �����´�.
        // sm.currentScore++;
        sm.SetScore(sm.GetScore() + 1);

        GameObject explosion = Instantiate(explosionFactory);

        explosion.transform.position = transform.position;

        // �� �װ�
        Destroy(collision.gameObject);
        // �� ����
        Destroy(gameObject);

        /*
        if (sm.currentScore > sm.bestScore)
        {
            sm.bestScore = sm.currentScore;

            sm.BestScoreUI.text = "�ְ� ���� : " + sm.bestScore;

            PlayerPrefs.SetInt("Best Score", sm.bestScore);
        }
        */

    }

}
