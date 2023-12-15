using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class FileSaver
{
    static string filePath = Application.persistentDataPath + "/holo.xml";
    public static List<Object> Load()
    {
        Debug.Log(filePath);
        if (File.Exists(filePath))
        {
            try
            {
                string xml = File.ReadAllText(filePath);

                XmlSerializer serializer = new XmlSerializer(typeof(List));

                using (StringReader reader = new StringReader(xml))
                {
                    var test = (List)serializer.Deserialize(reader);

                    // Access the deserialized data
                    foreach (var obj in test.Object)
                    {
                        Debug.Log($"Object Name: {obj.Name}");
                        Debug.Log($"Position: ({obj.Position.X}, {obj.Position.Y}, {obj.Position.Z})");
                        Debug.Log($"Rotation: ({obj.Rotation.X}, {obj.Rotation.Y}, {obj.Rotation.Z})");
                        Debug.Log($"Scale: ({obj.Scale.X}, {obj.Scale.Y}, {obj.Scale.Z})");
                        
                    }

                    return test.Object;
                }
            }
            catch (Exception e)
            {
                Debug.LogError($"Error reading or deserializing XML file: {e.Message}");
            }
        }
        else
        {
            Debug.LogError($"File not found at path: {filePath}");
            //File.Create(Application.persistentDataPath + "holo.xml");
            return null;
        }
        return null;
    }
    public static void SaveToXML(List<GameObject> dataList)
    {
        List<Object> objects = new List<Object>();
        if (dataList != null)
        {
            foreach (GameObject obj in dataList)
            {
                Transform transform = obj.transform;

                Object tempObj = new Object
                {
                    Name = obj.name,
                    Position = new Position
                    {
                        X = transform.position.x,
                        Y = transform.position.y,
                        Z = transform.position.z
                    },
                    Rotation =  new Rotation
                    {
                        X = transform.rotation.x,
                        Y = transform.rotation.y,
                        Z = transform.rotation.z
                    },
                    Scale = new Scale
                    {
                        X = transform.localScale.x,
                        Y = transform.localScale.y,
                        Z = transform.localScale.z
                    }
                };
                objects.Add( tempObj );

            }

            List list = new List
            {
                Object = objects
            };

            XmlSerializer serializer = new XmlSerializer(typeof(List));
            if (File.Exists(filePath))
            {
                File.Create(Application.persistentDataPath + "holo.xml");
            }

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, list);
            }

            Debug.Log($"Data saved to: {filePath}");
        }
    }
}
[XmlRoot(ElementName = "Position")]
public class Position
{

    [XmlElement(ElementName = "x")]
    public float X { get; set; }

    [XmlElement(ElementName = "y")]
    public float Y { get; set; }

    [XmlElement(ElementName = "z")]
    public float Z { get; set; }
}

[XmlRoot(ElementName = "Rotation")]
public class Rotation
{

    [XmlElement(ElementName = "x")]
    public float X { get; set; }

    [XmlElement(ElementName = "y")]
    public float Y { get; set; }

    [XmlElement(ElementName = "z")]
    public float Z { get; set; }
}

[XmlRoot(ElementName = "Scale")]
public class Scale
{

    [XmlElement(ElementName = "x")]
    public float X { get; set; }

    [XmlElement(ElementName = "y")]
    public float Y { get; set; }

    [XmlElement(ElementName = "z")]
    public float Z { get; set; }
}

[XmlRoot(ElementName = "Object")]
public class Object
{

    [XmlElement(ElementName = "Name")]
    public string Name { get; set; }

    [XmlElement(ElementName = "Position")]
    public Position Position { get; set; }

    [XmlElement(ElementName = "Rotation")]
    public Rotation Rotation { get; set; }

    [XmlElement(ElementName = "Scale")]
    public Scale Scale { get; set; }
}

[XmlRoot(ElementName = "List")]
public class List
{

    [XmlElement(ElementName = "Object")]
    public List<Object> Object { get; set; }
}