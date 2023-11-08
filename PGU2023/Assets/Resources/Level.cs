using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot(ElementName = "min")]
public class Min
{

    [XmlElement(ElementName = "Value")]
    public int Value { get; set; }

    [XmlElement(ElementName = "Cost")]
    public int Cost { get; set; }

    [XmlElement(ElementName = "Interest")]
    public int Interest { get; set; }

    [XmlElement(ElementName = "Functionality")]
    public int Functionality { get; set; }
}

[XmlRoot(ElementName = "max")]
public class Max
{

    [XmlElement(ElementName = "Value")]
    public int Value { get; set; }

    [XmlElement(ElementName = "Cost")]
    public int Cost { get; set; }

    [XmlElement(ElementName = "Interest")]
    public int Interest { get; set; }

    [XmlElement(ElementName = "Functionality")]
    public int Functionality { get; set; }
}

[XmlRoot(ElementName = "level")]
public class Level
{

    [XmlElement(ElementName = "Bombs")]
    public int Bombs { get; set; }

    [XmlElement(ElementName = "min")]
    public Min Min { get; set; }

    [XmlElement(ElementName = "max")]
    public Max Max { get; set; }

    [XmlElement(ElementName = "IconLevelPath")]
    public string IconLevelPath { get; set; }

    [XmlAttribute("Name")]
    public string Name { get; set; }

}

[XmlRoot(ElementName = "levels")]
public class Levels
{

    [XmlElement(ElementName = "level")]
    public List<Level> Level { get; set; }
}