using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Klasa odpowiedzialna za generowanie przeszk�d w grze.
/// </summary>
public class ObstacleSpawner : MonoBehaviour
{
    private System.Random generator;

    [SerializeField] public List<GameObject> trees; // Lista prefabrykat�w drzew
    [SerializeField] public GameObject fountain; // Prefabrykat fontanny

    /// <summary>
    /// Metoda wywo�ywana przy starcie sceny.
    /// </summary>
    void Start()
    {
        Spawn();
    }

    /// <summary>
    /// Metoda generuj�ca przeszkody w zale�no�ci od wylosowanych warto�ci.
    /// </summary>
    void Spawn()
    {
        generator = new System.Random();
        int k = generator.Next(100);

        // Sprawd�, czy warto�� k nie jest podzielna przez 3
        if (k % 3 != 0)
        {
            List<Transform> childrenList = new List<Transform>();

            // Pobierz list� dzieci obiektu
            foreach (Transform child in transform)
            {
                childrenList.Add(child);
                Debug.Log(child.name);
            }

            // Przetasuj list� dzieci
            ShuffleList(childrenList);

            int k1 = generator.Next(6);

            // Sprawd�, czy warto�� k1 jest podzielna przez 5
            if (k1 % 5 == 0)
            {
                // Wywo�aj metod� spawnFontain dla pierwszego dziecka na li�cie
                SpawnFontain(childrenList);
            }
            else
            {
                int k2 = generator.Next(3);
                int k3 = generator.Next(childrenList.Count);

                // Iteruj przez wylosowan� ilo�� dzieci i wywo�aj metod� spawnTree
                for (int i = 0; i < k3; i++)
                {
                    SpawnTree(k2, childrenList, i);
                }
            }
        }
    }

    /// <summary>
    /// Metoda generuj�ca drzewo na danej pozycji.
    /// </summary>
    /// <param name="k2">Indeks prefabrykatu drzewa w li�cie trees.</param>
    /// <param name="childrenList">Lista dzieci obiektu.</param>
    /// <param name="index">Indeks dziecka, na kt�rym zostanie umieszczone drzewo.</param>
    private void SpawnTree(int k2, List<Transform> childrenList, int index)
    {
        Vector3 pos = childrenList[index].gameObject.transform.position;
        GameObject temp = Instantiate(trees[k2], pos, Quaternion.identity);
        temp.transform.Rotate(-90, 0, 0);
    }

    /// <summary>
    /// Metoda generuj�ca fontann� na danej pozycji.
    /// </summary>
    /// <param name="childrenList">Lista dzieci obiektu.</param>
    private void SpawnFontain(List<Transform> childrenList)
    {
        Vector3 pos = childrenList[0].gameObject.transform.position;
        GameObject temp = Instantiate(fountain, pos, Quaternion.identity);
        temp.transform.Rotate(-90, 0, 0);
    }

    /// <summary>
    /// Metoda tasuj�ca list�.
    /// </summary>
    /// <typeparam name="T">Typ element�w listy.</typeparam>
    /// <param name="list">Lista do przetasowania.</param>
    static void ShuffleList<T>(List<T> list)
    {
        System.Random random = new System.Random();

        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
