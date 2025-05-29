using UnityEngine;

public class PlayerHeart : MonoBehaviour
{
    int heart = 3;

    public bool isGameOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true)
        {
            return;
        }

        if (heart == 2 || heart == 1)
        {
            transform.Rotate(0, 0, 30 * Time.deltaTime);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        heart -= 1;


        if (heart == 0)
        {
            Destroy(gameObject);
        }
    }
}
