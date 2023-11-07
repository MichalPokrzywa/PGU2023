using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 0.01f;
    Rigidbody rb;
    float translation;
    float straffe;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        translation = Input.GetAxis("Vertical") * speed * Time.fixedTime;
        straffe = Input.GetAxis("Horizontal") * speed * Time.fixedTime;


    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.forward * translation + transform.right * straffe);

    }
}
