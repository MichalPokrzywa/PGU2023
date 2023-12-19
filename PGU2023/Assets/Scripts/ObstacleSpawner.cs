using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    System.Random generator;
    [SerializeField] public List<GameObject> trees;
    [SerializeField] public GameObject fountain;
    // Start is called before the first frame update

    void Start()
    {
        spawn(); 
    }
    void spawn()
    {
        generator = new System.Random();
        int k = generator.Next(100);
        if (k % 3 != 0)
        {
            List<Transform> childrenList = new List<Transform>();

            foreach (Transform child in transform)
            {
                childrenList.Add(child);
                Debug.Log(child.name);
            }
            shuffleList(childrenList);


            int k1 = generator.Next(6);
            if(k1 % 5 == 0) 
            {
                spawnFontain(childrenList);
            }
            else
            {
                int k2 = generator.Next(3);
                int k3 = generator.Next(childrenList.Count);
                for(int i = 0; i < k3; i++) 
                {
                    spawnTree(k2, childrenList, i);
                }
            }

        }
    }

    private void spawnTree(int k2, List<Transform> childrenList, int index)
    {
        Vector3 pos = childrenList[index].gameObject.transform.position;
        GameObject temp = Instantiate(trees[k2], pos, Quaternion.identity);
        temp.transform.Rotate(-90, 0, 0);
    }
    private void spawnFontain(List<Transform> childrenList)
    {
        Vector3 pos = childrenList[0].gameObject.transform.position;
        GameObject temp = Instantiate(fountain, pos, Quaternion.identity);
        temp.transform.Rotate(-90,0,0);
    }

    static void shuffleList<T>(List<T> lista)
    {
        System.Random random = new System.Random();

        int n = lista.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            T wartosc = lista[k];
            lista[k] = lista[n];
            lista[n] = wartosc;
        }
    }
}
