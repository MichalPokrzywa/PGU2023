using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    private static HandManager _instance;
    public static HandManager instance => _instance;

    [SerializeField] private GameObject deck;

    public List<GameObject> cardObjects;
    [SerializeField] float cardWidth;
    [SerializeField] float maxNumberOfCarddsInHand;
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
    }

    public void add(GameObject card)
    {
        if (!(cardObjects.Count == maxNumberOfCarddsInHand))
        {

          /*  Debug.Log("y" + deck.transform.position.y);
            Debug.Log("z" + deck.transform.position.z);
            Debug.Log("x" + deck.transform.position.x);
            Debug.Log(1.2f * cardObjects.Count * cardWidth + " " + deck.transform.position.y + " " + deck.transform.position.z);*/
            Instantiate(card, new Vector3(deck.transform.position.x - (1.2f * (cardObjects.Count + 1) * cardWidth), deck.transform.position.y, deck.transform.position.z), Quaternion.identity, this.transform);
            cardObjects.Add(card);
        }
        //showCards();
    }

    void showCards()
    {
        //usunac stare
        foreach (GameObject g in cardObjects)
        {
            //g.Instantiate(tilePrefab, new Vector3(1.1f * i * tileSize, 0f, 1.1f * j * tileSize), Quaternion.identity, this.transform);
        }
    }

    public void chooseCard(GameObject card)
    {
        choosenCard = card;
    }

    public void removeCard(GameObject card)
    {
        Debug.Log(card);

        cardObjects.RemoveAll(item => item == card);
      /*  if (cardObjects.Contains(card))
        {
            cardObjects.Remove(card);
        }
        else
        {
            Debug.Log("Nie ma takiej karty w rece");
        }*/
        Debug.Log(cardObjects.Count);
    }

    public GameObject getChoosenCard()
    {
        return choosenCard;
    }

    public void moveCard(GameObject tile)
    {
        if (choosenCard == null) 
            return;
        //wizualizacja budynku w tym miejscu
        Debug.Log("Jestem tu w mroku, a dokladniej chce karte " + choosenCard.name + " na " + tile.name);
    }
}
