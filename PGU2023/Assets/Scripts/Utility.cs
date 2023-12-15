using System.Collections;
using System.IO;
using UnityEngine;

/// <summary>
/// Utility class for common functions.
/// </summary>
public class Utility
{
    /// <summary>
    /// Retrieves assets of type T located at the specified path.
    /// </summary>
    /// <typeparam name="T">The type of assets to retrieve.</typeparam>
    /// <param name="path">The relative path to the assets.</param>
    /// <returns>An array of assets of type T.</returns>
    //public static T[] GetAtPath<T>(string path)
    //{
    //    ArrayList al = new ArrayList();
    //    string[] fileEntries = Directory.GetFiles(Application.dataPath + "/" + path);
    //    foreach (string fileName in fileEntries)
    //    {
    //        int index = fileName.LastIndexOf("/");
    //        string localPath = "Assets/" + path;

    //        if (index > 0)
    //            localPath += fileName.Substring(index);

    //        Object t = UnityEditor.AssetDatabase.LoadAssetAtPath(localPath, typeof(T));

    //        if (t != null)
    //            al.Add(t);
    //    }
    //    T[] result = new T[al.Count];
    //    for (int i = 0; i < al.Count; i++)
    //        result[i] = (T)al[i];

    //    return result;
    //}
}
