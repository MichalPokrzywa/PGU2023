using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the movement and rotation of the camera based on mouse input.
/// </summary>
public class BeanCamera : MonoBehaviour
{
    [SerializeField] GameObject bean;
    [SerializeField] float headHeight = 0f;
    [SerializeField] float lookSpeed = 0f;

    private float rotationX;
    private float lookXLimit = 45f;

    void Update()
    {
        // Set the position of the camera above the bean character
        Vector3 playerPos = new Vector3(bean.transform.position.x, bean.transform.position.y + headHeight, bean.transform.position.z);
        this.transform.position = playerPos;
        this.transform.localRotation = Quaternion.identity;

        // Rotate the camera around the target point
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        // Rotate the parent object (character or object the camera follows) horizontally based on mouse input
        transform.parent.transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }
}
