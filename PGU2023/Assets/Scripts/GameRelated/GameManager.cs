using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.AI.Navigation;
using UnityEngine;



public class GameManager : MonoBehaviour
{

    private static GameManager _instance;
    public static GameManager instance => _instance;

    public int totalCost = 0;

    public int totalApartment = 0;

    public int totalBiodegradable = 0;

    public int totalTree = 0;
    public int totalDevelopment = 0;
    public int totalSurface = 0;
    public int totalFloors = 0;

    public bool isInWalkMode = false;

    public Symbol characterType = Symbol.Club;

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
        characterType = (Symbol)PlayerPrefs.GetInt("characterType");
        Debug.Log(characterType);

    }

    public void UpdateScore()
    {
        totalCost = 0;
        totalApartment = 0;
        totalBiodegradable = 0;
        totalTree = 0;
        totalDevelopment = 0;
        totalSurface = 0;
        totalFloors = 0;

        // Iterate through all tiles and update the scores
        foreach (TileObject tile in TileManager.instance.allTiles)
        {
            // Update scores based on tile values
            totalCost += tile.currentValue.value;
            totalApartment += tile.currentValue.cost;
            totalBiodegradable += tile.currentValue.interest;
            totalTree += tile.currentValue.functionality;
        }
        GameCanvas.instance.UpdateStats(totalCost, totalApartment, totalBiodegradable, totalTree);
    }
}
