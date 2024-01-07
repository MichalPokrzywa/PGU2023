using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardShowUI : MonoBehaviour
{
    [SerializeField] public List<TMP_Text> valuesText;
    [SerializeField] public Image cardImage;

    public void UpdateCard(CardObject cardObject)
    {
        Card card = cardObject.GetCardValues();
        Debug.Log(card);
        Texture2D texture = cardObject.GetCardTexture();
        cardImage.sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
        valuesText[0].text = card.Symbol;
        valuesText[1].text = card.Value.ToString();
        valuesText[2].text = card.Cost.ToString();
        valuesText[3].text = card.DevelopmentIntensity.ToString();
        valuesText[4].text = (card.SurfaceAreaPercentage * 100) + "%";
        valuesText[5].text = card.AverageNumberOfFloors.ToString();
        valuesText[6].text = card.NumberOfApartments.ToString();
        valuesText[7].text = (card.BiodegradableSurfacePercentage * 100) + "%";
        valuesText[8].text = card.TreeCount.ToString();
    }
}
