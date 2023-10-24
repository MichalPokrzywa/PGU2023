using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObject : MonoBehaviour
{
    CardObject card;

    public void PutCard(CardObject slottedCard)
    {
        card = slottedCard;
    }
}
