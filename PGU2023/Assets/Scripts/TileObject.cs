using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObject : MonoBehaviour
{
    CardObject card;
    public bool hasCard = false;

    void ShowBuilding()
    {
        card.Build();
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
            ShowBuilding();
        }
    }
}
