using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // StageData 불러오기
    [SerializeField]
    private StageData stageData;

    // 플레이어 이동할 속력
    public float speed = 5;

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        /*
        // 방향 만들기 : 벡터
        Vector3 dir = Vector3.right * h + Vector3.up * v;

        // vector3.up, vector3.down, vector3.left
        transform.Translate(dir * speed * Time.deltaTime);
        */

        Vector3 dir = new Vector3(h, v, 0);

        // P = P0 + vt 공식으로 변경
        // transform.position = transform.position + dir * speed * Time.deltaTime;
        transform.position += dir * speed * Time.deltaTime;
    }


    private void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x), Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y));
        transform.rotation = Quaternion.identity;
    }
}
