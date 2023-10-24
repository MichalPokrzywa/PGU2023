using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    private static HandManager _instance;
    public static HandManager instance => _instance;

    public List<GameObject> cardObjects;
    [SerializeField] float cardSize;
    [SerializeField] int cardStart;
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    void Start()
    {
        cardObjects = new List<GameObject>();
        for (int i = 0; i < cardStart; i++)
        {
            add(DeckManager.instance.getRandom());
        }
    }

    public void add(GameObject card)
    {
        Instantiate(card, new Vector3(1.2f * cardObjects.Count * cardSize, 0f, -13f), Quaternion.identity, this.transform);
        cardObjects.Add(card);
        //showCards();
    }

    void showCards()
    {
        //usunac stare
        foreach(GameObject g in cardObjects)
        {
            //g.Instantiate(tilePrefab, new Vector3(1.1f * i * tileSize, 0f, 1.1f * j * tileSize), Quaternion.identity, this.transform);
        }
        
    }

}
