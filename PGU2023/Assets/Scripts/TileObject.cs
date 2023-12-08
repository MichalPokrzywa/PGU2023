using System;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Represents a tile object in the game.
/// </summary>
public class TileObject : MonoBehaviour
{
    /// <summary>
    /// The card associated with the tile.
    /// </summary>
    public CardObject card;

    /// <summary>
    /// Indicates whether the tile has a card or not.
    /// </summary>
    public bool hasCard = false;

    /// <summary>
    /// The row index of the tile.
    /// </summary>
    public int row;

    /// <summary>
    /// The column index of the tile.
    /// </summary>
    public int col;

    /// <summary>
    /// The current value, cost, interest, and functionality of the tile.
    /// </summary>
    public (int value, int cost, int interest, int functionality) currentValue;

    /// <summary>
    /// The NavMeshSurface component used for pathfinding.
    /// </summary>
    public NavMeshSurface surface;

    /// <summary>
    /// The prefab for the person object.
    /// </summary>
    public GameObject personPrefab;

    /// <summary>
    /// Initializes the tile object.
    /// </summary>
    private void Start()
    {
        surface = GameObject.Find("NavMesh").GetComponent<NavMeshSurface>();
    }

    /// <summary>
    /// Shows the building associated with the card.
    /// </summary>
    /// <returns>True if the building is shown, false otherwise.</returns>
    bool ShowBuilding()
    {
        return card.Build();
    }

    /// <summary>
    /// Called when a collision with another object is ongoing.
    /// </summary>
    /// <param name="collision">The collision data.</param>
    void OnCollisionStay(Collision collision)
    {
        if (hasCard) return;

        if (collision.gameObject.GetComponent<CardObject>() == null) return;

        bool dragged = collision.gameObject.GetComponent<CardObject>().isDragged;

        if (!dragged)
        {
            hasCard = true;
            card = collision.gameObject.GetComponent<CardObject>();
            HandManager.instance.removeCard(card.gameObject);
            collision.gameObject.transform.parent = this.transform;
            if (!ShowBuilding())
            {
                hasCard = false;
            }
            else
            {
                currentValue = card.GetValueTuple();
                TileManager.instance.InformTiles(this);
            }
            AddPeople();
        }
    }

    /// <summary>
    /// Adds people to the tile and builds the NavMesh.
    /// </summary>
    private void AddPeople()
    {
        gameObject.layer = 3; // 3 = Tile layer
        surface.BuildNavMesh();
        Instantiate(personPrefab, transform.position, Quaternion.identity);
    }

    /// <summary>
    /// Assigns the row and column indices to the tile.
    /// </summary>
    /// <param name="row">The row index.</param>
    /// <param name="column">The column index.</param>
    public void AssignRowColumn(int row, int column)
    {
        this.row = row;
        this.col = column;
    }

    /// <summary>
    /// Updates the value of the tile based on the given card.
    /// </summary>
    /// <param name="card">The card object.</param>
    public void UpdateValue(CardObject card)
    {
        // Implementation goes here
    }

    /// <summary>
    /// Performs a special action on the tile based on the changed tile.
    /// </summary>
    /// <param name="changedTile">The changed tile object.</param>
    public void PerformSpecialAction(TileObject changedTile)
    {
        if (changedTile == null || card == null) return;

        currentValue = card.UpdateValue(currentValue);
    }

    /// <summary>
    /// Sends the current value, cost, interest, and functionality of the tile.
    /// </summary>
    /// <returns>A tuple containing the current value, cost, interest, and functionality.</returns>
    public (int currentValue, int currentCost, int currentInterest, int currrentFuntionality) sendScore()
    {
        return currentValue;
    }
}
