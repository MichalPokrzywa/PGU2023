using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class LevelColection : MonoBehaviour
{
    public List<Level> levels = new List<Level>();

    public static LevelColection LoadLevels(string path)
    {
        TextAsset _xml = Resources.Load<TextAsset>(path);
        MemoryStream stream = new MemoryStream(_xml.bytes);
        XmlSerializer serializer = new XmlSerializer(typeof(Levels));

        using (StreamReader reader = new StreamReader(stream))
        {
            var test = (Levels)serializer.Deserialize(reader);
            Debug.Log(test.Level.Count);
            return null;
        }

    }
}
