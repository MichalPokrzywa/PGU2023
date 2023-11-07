using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObject : MonoBehaviour
{
    public CardObject card;
    public bool hasCard = false;
    public int row, col;
    public (int value, int cost, int interest, int functionality) currentValue;
    bool ShowBuilding()
    {
        return card.Build();
    }


    void OnCollisionStay(Collision collision)
    {
        if(hasCard) return;
        
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
            
        }
    }
    public void AssignRowColumn(int row, int column)
    {
        this.row = row;
        this.col = column;
    }
    public void UpdateValue(CardObject card)
    {

    }
    public void PerformSpecialAction(TileObject changedTile)
    {
        if (changedTile == null || card == null) return;

        currentValue = card.UpdateValue(currentValue);
    }
    public (int currentValue, int currentCost, int currentInterest, int currrentFuntionality) sendScore()
    {
        return currentValue;
    }
}
