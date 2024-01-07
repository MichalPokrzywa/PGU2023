using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;

public class DrawCard : MonoBehaviour
{
    [SerializeField] public Image tmp;
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(GameManager.instance.isInWalkMode == true)
            {
                return;
            }

            int index = DeckManager.instance.getRandom();
            HandManager.instance.add(DeckManager.instance.cardObjects[index], DeckManager.instance.cardsList[index]);
            //wywolujemy handmanager: add
        }        
    }
}