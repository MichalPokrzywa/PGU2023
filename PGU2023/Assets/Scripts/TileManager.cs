using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Manages the tiles in the game.
/// </summary>
public class TileManager : MonoBehaviour
{
    private static TileManager _instance;
    public static TileManager instance => _instance;

    /// <summary>
    /// List of all the tiles in the game.
    /// </summary>
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

    /// <summary>
    /// Adds a tile to the list of all tiles.
    /// </summary>
    /// <param name="tile">The tile to add.</param>
    public void AddTile(TileObject tile)
    {
        if (!allTiles.Contains(tile))
        {
            allTiles.Add(tile);
        }
    }

    /// <summary>
    /// Informs neighboring tiles about a specific tile.
    /// </summary>
    /// <param name="tile">The tile to inform neighboring tiles about.</param>
    public void InformTiles(TileObject tile)
    {
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
        GameManager.instance.UpdateScore();
    }

    /// <summary>
    /// Sets the number of rows and columns in the game.
    /// </summary>
    /// <param name="rows">The number of rows.</param>
    /// <param name="col">The number of columns.</param>
    public void getRowsColumns(int rows, int col)
    {
        numRows = rows;
        numColumns = col;
    }

    /// <summary>
    /// Gets the neighboring tiles of a specific tile.
    /// </summary>
    /// <param name="tile">The tile to get the neighbors for.</param>
    /// <returns>A list of neighboring tiles.</returns>
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

    /// <summary>
    /// Gets a tile based on its row and column indices.
    /// </summary>
    /// <param name="row">The row index of the tile.</param>
    /// <param name="column">The column index of the tile.</param>
    /// <returns>The tile at the specified row and column indices, or null if the indices are invalid.</returns>
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
