using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    private static TileManager _instance;
    public static TileManager instance => _instance;

    public List<TileObject> allTiles = new List<TileObject>();
    int numRows;
    int numColumns;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void AddTile(TileObject tile)
    {
        if (!allTiles.Contains(tile))
        {
            allTiles.Add(tile);
        }
    }



    public void InformTiles(TileObject tile)
    {
        Debug.Log("hello");        
        // Iterate through neighboring tiles and perform actions
        foreach (TileObject neighbor in GetNeighborTiles(tile))
        {
            if (neighbor != null)
            {
                if (tile.card != null && tile.card.IsCardSpecial())
                {
                    // Perform a special action on neighboring tiles here
                    // For example, you can call a method on neighboring tiles
                    neighbor.PerformSpecialAction(tile);
                }
            }
        }
    }

    public void getRowsColumns(int rows, int col)
    {
        numRows = rows;
        numColumns = col;
    }
    List<TileObject> GetNeighborTiles(TileObject tile)
    {
        List<TileObject> neighbors = new List<TileObject>();
        int row = tile.row;
        int column = tile.col;


        if (row > 0) neighbors.Add(GetTileByRowAndColumn(row - 1, column)); // Top
        if (row < numRows ) neighbors.Add(GetTileByRowAndColumn(row + 1, column)); // Bottom
        if (column > 0) neighbors.Add(GetTileByRowAndColumn(row, column - 1)); // Left
        if (column < numColumns) neighbors.Add(GetTileByRowAndColumn(row, column + 1)); // Right

        return neighbors;
    }

    TileObject GetTileByRowAndColumn(int row, int column)
    {
        int index = row * numColumns + column;
        Debug.Log(index);
        if (index >= 0 && index < allTiles.Count)
        {
            return allTiles[index];
        }
        else
        {
            // Handle invalid indices or return null if needed
            return null;
        }
    }
}
