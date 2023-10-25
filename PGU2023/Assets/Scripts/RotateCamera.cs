using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public Transform target; // The position the camera should always look at
    public float rotationSpeed = 2.0f;
    public float zoomSpeed = 5.0f;
    public float minZoomDistance = 1.0f;
    public float maxZoomDistance = 10.0f;

    private float currentZoomDistance = 5.0f;

    private void Update()
    {
        if (target == null)
        {
            Debug.LogWarning("Target is not assigned. Please assign a target in the Inspector.");
            return;
        }

        // Get the input from the A and D keys
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the rotation angle based on the input and rotation speed
        float rotationAngle = horizontalInput * rotationSpeed;

        // Rotate the camera around the target
        transform.RotateAround(target.position, Vector3.up, rotationAngle);

        // Zoom in/out with the scroll wheel
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        currentZoomDistance -= scrollInput * zoomSpeed;
        currentZoomDistance = Mathf.Clamp(currentZoomDistance, minZoomDistance, maxZoomDistance);

        // Calculate the new camera position based on the zoom distance
        Vector3 zoomDirection = (transform.position - target.position).normalized;
        Vector3 newCameraPosition = target.position + zoomDirection * currentZoomDistance;

        // Update the camera position
        transform.position = newCameraPosition;

        // Make sure the camera always looks at the target
        transform.LookAt(target);
    }
}
