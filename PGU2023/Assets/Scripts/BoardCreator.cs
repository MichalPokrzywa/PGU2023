using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCreator : MonoBehaviour
{
    [SerializeField] GameObject tilePrefab;
    [SerializeField] int n;
    [SerializeField] int m;
    float tileSize;
    // Start is called before the first frame update
    
    void Start()
    {
        tileSize = tilePrefab.transform.localScale.x * 10;



        for (int i = 0; i < n; i++)
        {



            for (int j = 0; j < m; j++)
            {



                Instantiate(tilePrefab, new Vector3(1.1f * i * tileSize, 0f, 1.1f * j * tileSize), Quaternion.identity, this.transform);
            }
        }
    }



    // Update is called once per frame
    void Update()
    {

    }
}
