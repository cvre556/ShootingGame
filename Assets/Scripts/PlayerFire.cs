using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // �Ѿ��� ������ ����
    public GameObject bulletFactory;

    // �ѱ�
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
        // ����ڰ� �߻� ��ư�� ������
        if (Input.GetButtonDown("Fire1"))
        {
            // �Ѿ� ���忡�� �Ѿ��� �����
            GameObject bullet = Instantiate(bulletFactory);
            GameObject bullet2 = Instantiate(bulletFactory);
            //GameObject bullet3 = Instantiate(bulletFactory);


            // �Ѿ� �߻��Ѵ�

            bullet.transform.position = firePosition.transform.position;
            bullet2.transform.position = firePosition2.transform.position;
            // bullet3.transform.position = firePosition3.transform.position;
        }


    }
}
