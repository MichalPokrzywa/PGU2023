using System.Xml.Serialization;

public class Card {
    [XmlAttribute("Name")]
    public string Name { get; set; }

    [XmlElement("Symbol")]
    public string Symbol { get; set; }

    [XmlElement("Value")]
    public int Value { get; set; }

    [XmlElement("DevelopmentIntensity")]
    public float DevelopmentIntensity { get; set; }

    [XmlElement("SurfaceAreaPercentage")]
    public float SurfaceAreaPercentage { get; set; }

    [XmlElement("AverageNumberOfFloors")]
    public int AverageNumberOfFloors { get; set; }

    [XmlElement("NumberOfApartments")]
    public int NumberOfApartments { get; set; }

    [XmlElement("BiodegradableSurfacePercentage")]
    public float BiodegradableSurfacePercentage { get; set; }

    [XmlElement("TreeCount")]
    public int TreeCount { get; set; }

    [XmlElement("Cost")]
    public int Cost { get; set; }

    [XmlElement("GameObjectPath")]
    public string GameObjectPath { get; set; }

    [XmlElement("MaterialPath")]
    public string MaterialPath { get; set; }

    [XmlElement("IsSpecial")]
    public bool IsSpecial { get; set; }
}
