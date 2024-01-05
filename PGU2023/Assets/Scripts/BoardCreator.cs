using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCreator : MonoBehaviour
{
    [SerializeField] GameObject tilePrefab;
    [SerializeField] int n;
    [SerializeField] int m;
    [SerializeField] float tileSize;
    public Symbol symbol = Symbol.Club;
    // Start is called before the first frame update
    void Start()
    {        
        TileManager.instance.getRowsColumns(n, m);
        Vector3 initialPosition = new Vector3();
        initialPosition.x = transform.position.x - ((n * 1.0f / 2) * tileSize) + 0.5f * tileSize;
        initialPosition.y = transform.position.y;
        initialPosition.z = transform.position.z - ((m * 1.0f / 2) * tileSize) + 0.5f * tileSize;
        List<int> specjals = new List<int>();
        //0.3 == 30% max specjal hex
        for (int i = 1; i < n * m * 0.3;  i++)
        {
            int next = Random.Range(0, n * m);
            specjals.Add(next);
        }
        for (int i = 0; i < n; i++) 
        {
            for(int j = 0; j < m; j++) 
            {
                GameObject temp = Instantiate(tilePrefab,new Vector3(i * tileSize + initialPosition.x , transform.position.y, j *tileSize + initialPosition.z), Quaternion.identity,this.transform);
                if (specjals.Contains(i * m + j))
                {
                    temp.GetComponent<TileObject>().setSpecjal(symbol);
                }
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
