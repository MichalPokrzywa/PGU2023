using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    List<GameObject> cameraObjects;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Camera camera in gameObject.GetComponentsInChildren<Camera>())
        {
            cameraObjects.Add(camera.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
