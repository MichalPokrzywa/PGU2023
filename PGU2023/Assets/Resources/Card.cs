using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Card {
    [XmlAttribute("Name")]
    public string Name { get; set; }

    [XmlElement("Symbol")]
    public string Symbol { get; set; }

    [XmlElement("Value")]
    public int Value { get; set; }

    [XmlElement("Cost")]
    public int Cost { get; set; }

    [XmlElement("Interest")]
    public int Interest { get; set; }

    [XmlElement("Functionality")]
    public int Functionality { get; set; }

    [XmlElement("GameObjectPath")]
    public string GameObjectPath { get; set; }

    [XmlElement("IsSpecial")]
    public bool IsSpecial { get; set; }
}
