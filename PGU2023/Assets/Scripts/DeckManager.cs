using System.Collections;
using System.IO;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    private static DeckManager _instance;
    public static DeckManager instance => _instance;

    public GameObject[] cardObjects;
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
        LoadCardsGameObjects();   
    }

    void LoadCardsGameObjects()
    {
        cardObjects = Utility.GetAtPath<GameObject>("Prefabs/Cards/");
    }

    public GameObject getRandom()
    {
        int index = Random.Range(0, cardObjects.Length);
        
        Debug.Log(cardObjects[index].name);

        //usunac karte z talii (moze kiedys)

        return cardObjects[index];
    }
}
