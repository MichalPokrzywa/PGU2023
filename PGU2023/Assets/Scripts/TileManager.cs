using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    private static TileManager _instance;
    public static TileManager instance => _instance;

    private List<TileObject> allTiles = new List<TileObject>();
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
    }
}
