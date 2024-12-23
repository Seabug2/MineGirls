using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject tile;

    public int x = 5;
    public int y = 5;

    void Start()
    {
        for (int i = 0; i < x; i++)
            for (int j = 0; j < y; j++)
            {
                if (i == 0 && j == 0) continue;
                Instantiate(this.tile, new Vector3(i, 0, j), Quaternion.identity);
            }
    }
}
