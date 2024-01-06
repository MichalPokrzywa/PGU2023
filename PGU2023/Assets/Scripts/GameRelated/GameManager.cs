using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.AI.Navigation;
using UnityEngine;



public class GameManager : MonoBehaviour
{

    private static GameManager _instance;
    public static GameManager instance => _instance;

    public int totalValue = 0;

    public int totalCost = 0;

    public int totalInterest = 0;

    public int totalFunctionality = 0;

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
        totalValue = 0;
        totalCost = 0;
        totalInterest = 0;
        totalFunctionality = 0;

        // Iterate through all tiles and update the scores
        foreach (TileObject tile in TileManager.instance.allTiles)
        {
            // Update scores based on tile values
            totalValue += tile.currentValue.value;
            totalCost += tile.currentValue.cost;
            totalInterest += tile.currentValue.interest;
            totalFunctionality += tile.currentValue.functionality;
        }
        GameCanvas.instance.UpdateStats(totalValue, totalCost, totalInterest, totalFunctionality);
    }
}
