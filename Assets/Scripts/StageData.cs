using UnityEngine;


[CreateAssetMenu]
public class StageData : ScriptableObject
{
    [SerializeField]
    private Vector2 limitMin;
    [SerializeField]
    private Vector2 limitMax;

    // 아이템/스킬, 게임 내 데이터, 씬 사이에 유지하는 데이터 
    public Vector2 LimitMin => limitMin;
    public Vector2 LimitMax => limitMax;
}
