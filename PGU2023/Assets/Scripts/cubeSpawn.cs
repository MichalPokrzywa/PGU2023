using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeSpawn : MonoBehaviour
{
    public GameObject cube;
    List<GameObject> cubeList = new List<GameObject>();

    public void spawnCube()
    {
        GameObject temp = Instantiate(cube);
        cubeList.Add(temp);
    }

    void Start()
    {
        // Create GameObjects based on the loaded data
        if (FileSaver.Load() != null)
        {
            foreach (var serializableObject in FileSaver.Load())
            {
                GameObject newObject = Instantiate(cube);
                newObject.transform.position = new Vector3(serializableObject.Position.X, serializableObject.Position.Y, serializableObject.Position.Z);
                newObject.transform.rotation = Quaternion.Euler(serializableObject.Rotation.X, serializableObject.Rotation.Y, serializableObject.Rotation.Z);
                newObject.transform.localScale = new Vector3(serializableObject.Scale.X, serializableObject.Scale.Y, serializableObject.Scale.Z);
                newObject.name = serializableObject.Name;
                // Add newObject to a list or perform other actions as needed
                cubeList.Add(newObject);
            }
        }
    }

    void OnApplicationQuit()
    {
        FileSaver.SaveToXML(cubeList);
    }
}
