using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    public int size = 100;

    private Cell[,] _cellgrid;
    
    // Start is called before the first frame update
    void Start()
    {
        _cellgrid = new Cell[size, size];
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                Cell cell = new Cell();
                cell.isWater = true;
                _cellgrid[x, y] = cell;
            }
        }
    }


    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        for (int y = 0; y < size; y++)
        {

            for (int x = 0; x < size; x++)
            {
                Cell cell = _cellgrid[x, y];

                if (cell.isWater)
                {
                    Gizmos.color = Color.blue;
                }
                else
                {
                    Gizmos.color = Color.green;
                }

                Vector3 pos = new Vector3(x, 0, y);
                Gizmos.DrawCube(pos, Vector3.one);
            }
        }
        
    }

    void Update()
    {
        
    }
}
