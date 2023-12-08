using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the creation of a board composed of tiles based on specified dimensions and tile size.
/// </summary>
public class BoardCreator : MonoBehaviour
{
    [SerializeField] GameObject tilePrefab; // Prefab of the tile object
    [SerializeField] int n; // Number of rows
    [SerializeField] int m; // Number of columns
    [SerializeField] float tileSize; // Size of each tile

    // Start is called before the first frame update
    void Start()
    {
        // Get the rows and columns from the TileManager instance
        TileManager.instance.getRowsColumns(n, m);

        // Create tiles based on specified rows and columns
        for (int i = 0; i < n; i++) 
        {
            for(int j = 0; j < m; j++) 
            {
                // Instantiate a tile at the specified position
                GameObject temp = Instantiate(tilePrefab, new Vector3(i * tileSize + transform.position.x , transform.position.y, j * tileSize + transform.position.z), Quaternion.identity, this.transform);
                temp.name = temp.name + i + j;
                
                // Assign row and column values to the TileObject component of the tile
                temp.GetComponent<TileObject>().AssignRowColumn(i, j);

                // Add the tile to the TileManager
                TileManager.instance.AddTile(temp.GetComponent<TileObject>());
            }
        }
    }

    /// <summary>
    /// Gets the total number of tiles created on the board.
    /// </summary>
    /// <returns>The total number of tiles.</returns>
    public int getNumberOfTiles()
    {
        return n * m;
    }
}
