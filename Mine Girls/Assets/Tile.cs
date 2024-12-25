using UnityEngine;

public class Tile : MonoBehaviour
{
    public int X { get; set; }
    public int Y { get; set; }

    [SerializeField] private Vector3 offset = Vector3.up;   // 텍스트 위치 오프셋
    [SerializeField] private Color textColor = Color.white; // 텍스트 색상

    public Tile Init(int x, int y)
    {
        X = x;
        Y = y;
        return this;
    }

    private void OnDrawGizmos()
    {
#if UNITY_EDITOR
        // 텍스트 색상 스타일 설정
        GUIStyle style = new GUIStyle
        {
            normal = { textColor = textColor },
            alignment = TextAnchor.MiddleCenter,
            fontSize = 14
        };

        // 텍스트 위치 설정
        Vector3 labelPosition = transform.position + offset;

        // 텍스트 표시
        UnityEditor.Handles.Label(labelPosition, $"{X}, {Y}", style);
#endif
    }
}
