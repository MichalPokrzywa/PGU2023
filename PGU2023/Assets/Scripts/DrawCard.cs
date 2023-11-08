using UnityEngine;
using System.Collections;

public class DrawCard : MonoBehaviour
{
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(GameManager.instance.isInWalkMode == true)
            {
                return;
            }
            GameObject card = DeckManager.instance.getRandom();
            /*Debug.Log(card.name);*/
            HandManager.instance.add(card);
            //wywolujemy handmanager: add
        }        
    }
}