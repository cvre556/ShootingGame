using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 총알을 생성할 공장
    public GameObject bulletFactory;

    // 총구
    public GameObject firePosition;
    public GameObject firePosition2;
    //public GameObject firePosition3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 사용자가 발사 버튼을 누르면
        if (Input.GetButtonDown("Fire1"))
        {
            // 총알 공장에서 총알을 만든다
            GameObject bullet = Instantiate(bulletFactory);
            GameObject bullet2 = Instantiate(bulletFactory);
            //GameObject bullet3 = Instantiate(bulletFactory);


            // 총알 발사한다

            bullet.transform.position = firePosition.transform.position;
            bullet2.transform.position = firePosition2.transform.position;
            // bullet3.transform.position = firePosition3.transform.position;
        }


    }
}
