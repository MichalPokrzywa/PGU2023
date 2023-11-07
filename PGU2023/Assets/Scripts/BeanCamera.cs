using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanCamera : MonoBehaviour
{
    [SerializeField] GameObject bean;
    [SerializeField] float headHight = 0f;
    [SerializeField] float lookSpeed = 0f;

    private float rotationX;
    private float lookXLimit = 45f;

    void Update()
    {
        Vector3 playerPos = new Vector3(bean.transform.position.x, bean.transform.position.y + headHight, bean.transform.position.z);
        this.transform.position = playerPos;
        this.transform.localRotation = Quaternion.identity;


        // Obrót kamery wokó³ punktu docelowego
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        transform.parent.transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);


    }
}
