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

    public float totalBiodegradable = 0;

    public int totalTree = 0;
    public float totalDevelopment = 0;
    public float totalSurface = 0;
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
        int counter = 0;
        // Iterate through all tiles and update the scores
        foreach (TileObject tile in TileManager.instance.allTiles)
        {
            Debug.Log(tile.card);
            // Update scores based on tile values
            CardObject card = tile.card;
            if(tile.card != null)
            {
                counter += 1;
                totalCost += card.cost;
                totalApartment += card.apartments;
                totalBiodegradable += card.bioSurface;
                totalTree += card.tree;
                totalDevelopment += card.intensityDev;
                totalSurface += card.areaSurface;
                totalFloors += card.averageFloors;
            }
            
        }

        totalBiodegradable /= counter;
        totalSurface  /= counter;
        totalFloors /= counter;
        GameCanvas.instance.UpdateStats(totalCost, totalApartment, totalBiodegradable, totalTree, totalDevelopment, totalSurface, totalFloors);
    }
}
