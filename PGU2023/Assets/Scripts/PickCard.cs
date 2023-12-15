using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a script attached to a card object that allows the player to pick the card.
/// </summary>
public class PickCard : MonoBehaviour
{
    /// <summary>
    /// Called when the mouse is over the card object.
    /// </summary>
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            if(GameManager.instance.isInWalkMode == true)
            {
                return;
            }
            HandManager.instance.chooseCard(this.gameObject);
        }
    }
}
