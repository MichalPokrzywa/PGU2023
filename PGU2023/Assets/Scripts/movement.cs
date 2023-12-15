using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Controls the movement of the game object.
/// </summary>
public class movement : MonoBehaviour
{
    public float speed = 0.01f;
    public float maxSpeed = 0.1f;
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
        translation = Input.GetAxisRaw("Vertical") * speed * Time.fixedTime;
        straffe = Input.GetAxisRaw("Horizontal") * speed * Time.fixedTime;
    }

    void FixedUpdate()
    {
        Vector3 move = transform.forward * translation + transform.right * straffe;
        rb.MovePosition(transform.position + move.normalized * Mathf.Clamp(move.magnitude, 0, maxSpeed));

    }
}
