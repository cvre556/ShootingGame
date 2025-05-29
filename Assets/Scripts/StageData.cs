using UnityEngine;


[CreateAssetMenu]
public class StageData : ScriptableObject
{
    [SerializeField]
    private Vector2 limitMin;
    [SerializeField]
    private Vector2 limitMax;

    // ������/��ų, ���� �� ������, �� ���̿� �����ϴ� ������ 
    public Vector2 LimitMin => limitMin;
    public Vector2 LimitMax => limitMax;
}
