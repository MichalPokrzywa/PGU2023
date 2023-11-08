using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] GameObject table;
    public float speed = 0.01f;
    Rigidbody rb;
    float translation;
    float straffe;
    private Transform tableSize;
    public float margin = 0.001f;

    Vector3 borderPos;
    float borderWidth;
    float borderLength;

    // Oblicz granice ruchu postaci
    float minX;
    float maxX;
    float minZ;
    float maxZ;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (table != null)
        {
            tableSize = table.transform;
            borderPos = tableSize.position;
            borderWidth = tableSize.localScale.x;
            borderLength = tableSize.localScale.z;
            minX = borderPos.x - borderWidth / 2 + margin;
            maxX = borderPos.x + borderWidth / 2 - margin;
            minZ = borderPos.z - borderLength / 2 + margin;
            maxZ = borderPos.z + borderLength / 2 - margin;
        }
    }

    // Update is called once per frame
    void Update()
    {
        translation = Input.GetAxis("Vertical") * speed * Time.fixedTime;
        straffe = Input.GetAxis("Horizontal") * speed * Time.fixedTime;

        Vector3 ruch = new Vector3(straffe, 0, translation);
        Vector3 nowaPozycja = rb.position + ruch;

        // Ogranicz ruch postaci do granic obiektu granicznego
        nowaPozycja.x = Mathf.Clamp(nowaPozycja.x, minX, maxX);
        nowaPozycja.z = Mathf.Clamp(nowaPozycja.z, minZ, maxZ);

        // Ustaw now¹ pozycjê postaci
        //rb.MovePosition(nowaPozycja);
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.forward * translation + transform.right * straffe);

    }
}
