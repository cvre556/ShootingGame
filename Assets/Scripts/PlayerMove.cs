using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // StageData �ҷ�����
    [SerializeField]
    private StageData stageData;

    // �÷��̾� �̵��� �ӷ�
    public float speed = 5;

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        /*
        // ���� ����� : ����
        Vector3 dir = Vector3.right * h + Vector3.up * v;

        // vector3.up, vector3.down, vector3.left
        transform.Translate(dir * speed * Time.deltaTime);
        */

        Vector3 dir = new Vector3(h, v, 0);

        // P = P0 + vt �������� ����
        // transform.position = transform.position + dir * speed * Time.deltaTime;
        transform.position += dir * speed * Time.deltaTime;
    }


    private void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x), Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y));
        transform.rotation = Quaternion.identity;
    }
}
