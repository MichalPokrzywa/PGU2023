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
            GameObject card = DeckManager.instance.getRandom();
            Texture2D texture = card.GetComponent<CardObject>().GetCardTexture();
            tmp.sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
            HandManager.instance.add(card);
            //wywolujemy handmanager: add
        }        
    }
}