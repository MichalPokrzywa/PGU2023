using UnityEngine;
using System.Collections;

/// <summary>
/// Represents a script attached to a game object that allows the player to draw a card.
/// </summary>
public class DrawCard : MonoBehaviour
{
    /// <summary>
    /// Called when the mouse is over the game object.
    /// </summary>
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(GameManager.instance.isInWalkMode == true)
            {
                return;
            }
            GameObject card = DeckManager.instance.getRandom();
            
            HandManager.instance.add(card);
            //wywolujemy handmanager: add
        }        
    }
}