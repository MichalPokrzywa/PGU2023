using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObject : MonoBehaviour
{
    CardObject card;
    public bool hasCard = false;
    (int value, int cost, int interest, int functionality) currentValue;
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
                TileManager.instance.InformTiles(this);
                currentValue = card.GetValueTuple();
            }
            
        }
    }

    public void UpdateValue(CardObject card)
    {

    }
    public void TileChanged(TileObject changedTile)
    {
        
    }
    public (int currentValue, int currentCost, int currentInterest, int currrentFuntionality) sendScore()
    {
        return currentValue;
    }
}
