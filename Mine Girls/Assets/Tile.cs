using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public static class Tiles
{
    public static readonly Dictionary<(int, int), Tile> Dictionary = new();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
    static void RegUnloadSceneAction()
    {
        SceneManager.sceneUnloaded += (_) => Dictionary.Clear();
    }

    public static void Add((int, int) position, Tile tile)
    {
        if (Dictionary.ContainsKey(position))
        {
            Object.Destroy(tile.gameObject);
        }
        else
        {
            Dictionary.Add(position, tile);
        }
    }

    public static Tile Get(int x, int y)
    {
        return Dictionary[(x, y)];
    }

    public static bool TryGet(int x, int y, out Tile tile)
    {
        if (Dictionary.ContainsKey((x, y)))
        {
            tile = Dictionary[(x, y)];
            return true;
        }
        else
        {
            tile = null;
            return false;
        }
    }
}

public class Tile : MonoBehaviour
{
    public (int, int) GetPosition()
    {
        int x = Mathf.RoundToInt(transform.position.x);
        int y = Mathf.RoundToInt(transform.position.y);
        transform.position.Set(x, y, 0);
        return (x, y);
    }

    protected virtual void Awake()
    {
        Tiles.Add(GetPosition(), this);
    }

    public bool NextTile ((int, int) targetPosition)
    {
        //�������� ��ġ ��
        (int x, int y) = targetPosition;

        return false;
    }

    public int X { get; set; }
    public int Y { get; set; }

    [SerializeField] private Vector3 offset = Vector3.up;   // �ؽ�Ʈ ��ġ ������
    [SerializeField] private Color textColor = Color.white; // �ؽ�Ʈ ����

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
        UnityEditor.Handles.Label(labelPosition, $"{transform.position.x}, {transform.position.z}", style);
#endif
    }
}
