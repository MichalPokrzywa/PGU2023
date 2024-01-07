using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    private static DeckManager _instance;
    public static DeckManager instance => _instance;

    public GameObject cardPrefab;

    public List<GameObject> cardObjects;
    public List<Card> cardsList = new List<Card>();

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
        CardsColection cardsColection = CardsColection.LoadCards("newcards");
        cardsList = cardsColection.cards;
        Debug.Log(cardsColection.cards.Count);
        foreach (Card card in cardsColection.cards)
        {
            Debug.Log(card.GameObjectPath);
            CreateCard(card);
        }
        Debug.Log(cardsList);
        //cardObjects = Utility.GetAtPath<GameObject>("Prefabs/CardsColection/");
    }

    void CreateCard(Card card)
    {
        GameObject newCard = Instantiate(cardPrefab);
        newCard.hideFlags = HideFlags.HideInHierarchy;
        if (card.IsSpecial)
        {
            newCard.AddComponent<SpecjalCard>();
        }
        else
        {
            newCard.AddComponent<BaseCard>();
        }

        CardObject cardObject = newCard.GetComponent<CardObject>();
        cardObject.SetCardValues(card);
        newCard.name = card.Name;
        cardObjects.Add(newCard);
    }

    public int getRandom()
    {
        int index = Random.Range(0, cardObjects.Count);
        
        Debug.Log(cardObjects[index]);
        return index;
        //usunac karte z talii (moze kiedys)

    }
}
