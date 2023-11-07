using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCreator : MonoBehaviour
{
    [SerializeField] GameObject tilePrefab;
    [SerializeField] int n;
    [SerializeField] int m;
    [SerializeField] float tileSize;
    // Start is called before the first frame update
    void Start()
    {
        TileManager.instance.getRowsColumns(n, m);
        for (int i = 0; i < n; i++) 
        {
            for(int j = 0; j < m; j++) 
            {
                GameObject temp = Instantiate(tilePrefab,new Vector3(i * tileSize + transform.position.x , transform.position.y, j *tileSize + transform.position.z), Quaternion.identity,this.transform);
                temp.name = temp.name + i + j;
                temp.GetComponent<TileObject>().AssignRowColumn(i,j);
                TileManager.instance.AddTile(temp.GetComponent<TileObject>());
            }
        }
    }

    public int getNumberOfTiles()
    {
        return n * m;
    }

}
