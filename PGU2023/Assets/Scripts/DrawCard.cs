using UnityEngine;
using System.Collections;

public class DrawCard : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        // Get a reference to the main camera.
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Check for mouse input (left-click) to cast a ray.
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse pointer into the scene.
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits any objects.
            if (Physics.Raycast(ray, out hit))
            {
                // An object has been hit.
                Debug.Log("Hit object: " + hit.collider.gameObject.name);
            }
        }
    }

    private void OnMouseOver()
    {
        //Debug.Log("Hywymydyzy");
    }
}