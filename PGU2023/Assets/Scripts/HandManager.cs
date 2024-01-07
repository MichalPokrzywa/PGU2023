using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    private static HandManager _instance;
    public static HandManager instance => _instance;

    public List<GameObject> cardObjects;
    [SerializeField] float cardWidth;
    [SerializeField] float maxNumberOfCarddsInHand;
    private int cardsDrawn = 0;
    private int maxNumberOfCardsToDraw;
    public GameObject boardCreator;
    public GameObject choosenCard;
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
        choosenCard = null;
        cardObjects = new List<GameObject>();
        maxNumberOfCardsToDraw = boardCreator.GetComponent<BoardCreator>().getNumberOfTiles();
        maxNumberOfCardsToDraw += BombManager.instance.getBombCount();
    }

    public void add(GameObject card,Card cardValue)
    {
        if (cardObjects.Count == maxNumberOfCarddsInHand)
        {
            Debug.Log("Warunek A");
            return;
        }
        if (cardsDrawn == maxNumberOfCardsToDraw)
        {
            //Debug.Log("Warunek B");
            return;
        }
        
        GameObject temp = Instantiate(card, new Vector3(DeckManager.instance.transform.position.x - (3.6f * (cardObjects.Count + 1) * cardWidth), DeckManager.instance.transform.position.y, DeckManager.instance.transform.position.z), Quaternion.identity, this.transform);
        temp.GetComponent<CardObject>().setIndex(cardObjects.Count);
        temp.GetComponent<CardObject>().SetCard(cardValue);
        cardObjects.Add(temp);
        temp.hideFlags = HideFlags.None;
        cardsDrawn++;
        
    }

    public void chooseCard(GameObject card)
    {
        choosenCard = card;
    }

    public void updateHand()
    {
        for (int i = 0; i < cardObjects.Count; i++)
        {
            cardObjects[i].transform.position =
                new Vector3(DeckManager.instance.transform.position.x - (3.6f * (i + 1) * cardWidth),
                    DeckManager.instance.transform.position.y, DeckManager.instance.transform.position.z);
        }
    }
    public void removeCard(GameObject card)
    {
        //Debug.Log(card);

        if (cardObjects.Contains(card))
        {
            cardObjects.Remove(card);
            updateHand();
        }
        else
        {
            Debug.Log("Nie ma takiej karty w rece");
        }
    }

    public void removeCard(int index)
    {
        //Debug.Log(card);

        if (index >= cardObjects.Count)
        {
            Debug.Log("Nie ma takiej karty w rece");
        }
        else
        {
            Debug.Log("Usuwam karte o indeksie " + index);
            cardObjects.RemoveAt(index);
            updateHand();
        }
    }
}
