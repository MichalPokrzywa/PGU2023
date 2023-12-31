using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class LevelColection : MonoBehaviour
{

    public static List<Level> LoadLevels(string path)
    {
        TextAsset _xml = Resources.Load<TextAsset>(path);
        MemoryStream stream = new MemoryStream(_xml.bytes);
        XmlSerializer serializer = new XmlSerializer(typeof(Levels));

        using (StreamReader reader = new StreamReader(stream))
        {
            var test = (Levels)serializer.Deserialize(reader);
            return test.Level;
        }

    }
}
