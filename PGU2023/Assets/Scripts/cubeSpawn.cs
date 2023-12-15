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
}
