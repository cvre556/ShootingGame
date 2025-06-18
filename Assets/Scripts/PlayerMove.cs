using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;

    public float speed = 5;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, v, 0);
        transform.position += dir * speed * Time.deltaTime;
    }

    private void LateUpdate()
    {
        
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
            Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y),
            transform.position.z
        );

        
        Vector3 rot = transform.eulerAngles;
        rot.y = 0f;
        rot.z = 0f;
        transform.eulerAngles = rot;
    }
}
