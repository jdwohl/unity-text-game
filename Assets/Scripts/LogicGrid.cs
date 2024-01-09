using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicGrid : MonoBehaviour
{

    public Square[] grid = new Square[5];
    public string description = "hello";

    public void initializeGrid()
    {
        grid[0] = new Square("a1", 0, 1, "knife", "hello");
    }

    public bool searchGrid(string squareName)
    {
        bool squareFound = false;

        for (int i = 0; i < grid.Length; i++)
        {
            if(grid[i].name == squareName)
            {
                squareFound = true;
                break;
            }
        }
        return squareFound;
    }
}
