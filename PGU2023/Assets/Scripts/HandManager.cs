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
    }

    public void add(GameObject card)
    {
        if (cardObjects.Count == maxNumberOfCarddsInHand) return;
        if (cardsDrawn == maxNumberOfCardsToDraw) return;
        
            GameObject temp = Instantiate(card, new Vector3(DeckManager.instance.transform.position.x - (1.2f * (cardObjects.Count + 1) * cardWidth), DeckManager.instance.transform.position.y, DeckManager.instance.transform.position.z), Quaternion.identity, this.transform);
            cardObjects.Add(temp);
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
                new Vector3(DeckManager.instance.transform.position.x - (1.2f * (i + 1) * cardWidth),
                    DeckManager.instance.transform.position.y, DeckManager.instance.transform.position.z);
        }
    }
    public void removeCard(GameObject card)
    {
        Debug.Log(card);

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
}
