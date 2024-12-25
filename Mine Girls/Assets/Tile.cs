using UnityEngine;

public class Tile : MonoBehaviour
{
    public int X { get; set; }
    public int Y { get; set; }

    [SerializeField] private Vector3 offset = Vector3.up;   // �ؽ�Ʈ ��ġ ������
    [SerializeField] private Color textColor = Color.white; // �ؽ�Ʈ ����

    public Tile Init(int x, int y)
    {
        X = x;
        Y = y;
        return this;
    }

    private void OnDrawGizmos()
    {
#if UNITY_EDITOR
        // �ؽ�Ʈ ���� ��Ÿ�� ����
        GUIStyle style = new GUIStyle
        {
            normal = { textColor = textColor },
            alignment = TextAnchor.MiddleCenter,
            fontSize = 14
        };

        // �ؽ�Ʈ ��ġ ����
        Vector3 labelPosition = transform.position + offset;

        // �ؽ�Ʈ ǥ��
        UnityEditor.Handles.Label(labelPosition, $"{X}, {Y}", style);
#endif
    }
}
