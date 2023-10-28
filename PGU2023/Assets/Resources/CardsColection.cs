using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

[XmlRoot("CardsColection")]
public class CardsColection
{
    [XmlArray("Cards")]
    [XmlArrayItem("Card")]
    public List<Card> cards = new List<Card>();

    public static CardsColection LoadCards(string path)
    {

        TextAsset _xml = Resources.Load<TextAsset>(path);
        XmlSerializer serializer = new XmlSerializer(typeof(CardsColection));
        StringReader reader = new StringReader(_xml.text);
        CardsColection cardsColection = serializer.Deserialize(reader) as CardsColection;
        reader.Close();
        if (cardsColection == null)
        {
                Debug.LogError("Failed to deserialize XML data.");
        }

        return cardsColection;
    }

}
