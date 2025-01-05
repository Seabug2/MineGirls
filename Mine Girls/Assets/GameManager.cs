using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public GameObject tile;

    //public int x = 5;
    //public int y = 5;

    //void Start()
    //{
    //    for (int i = 0; i < x; i++)
    //        for (int j = 0; j < y; j++)
    //        {
    //            if (i == 0 && j == 0) continue;
    //            Instantiate(this.tile, new Vector3(i, 0, j), Quaternion.identity);
    //        }
    //}

    public Tile tile;
    public Tile[,] tiles;

    public int x;
    public int y;

    private void Start()
    {
        tile.gameObject.SetActive(false);
        int colLimit = x + x - 1;
        tiles = new Tile[colLimit, y];

        float colsRange = Mathf.Sin(Mathf.Deg2Rad * 60) * 2;

        int col = 0;
        for (int row = 0; row < y; row++)
        {
            for (; col < colLimit; col += 2)
            {
                Tile t = Instantiate(tile, new Vector3(col, 0, row * colsRange), Quaternion.identity);
                //tiles[col, row] = t.Init(col, row);
                t.gameObject.SetActive(true);
            }

            if (col >= colLimit)
            {
                col %= colLimit;
            }
        }
    }
}
