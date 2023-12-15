using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.AI.Navigation;
using UnityEngine;

/// <summary>
/// Manages the game's overall progress and scores.
/// </summary>
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager instance => _instance;

    public int totalValue = 0; // Total value accumulated in the game
    public int totalCost = 0; // Total cost incurred in the game
    public int totalInterest = 0; // Total interest gained in the game
    public int totalFunctionality = 0; // Total functionality achieved in the game

    public bool isInWalkMode = false; // Indicates whether the game is in "walk mode"

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
    /// Updates the overall scores based on the current state of the game.
    /// </summary>
    public void UpdateScore()
    {
        // Reset the scores
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

        // Update the UI with the new scores
        GameCanvas.instance.UpdateStats(totalValue, totalCost, totalInterest, totalFunctionality);
    }
}
