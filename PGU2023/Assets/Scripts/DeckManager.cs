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
        Debug.Log(cardsColection.cards.Count);
        foreach (Card card in cardsColection.cards)
        {
            Debug.Log(card.GameObjectPath);
            CreateCard(card);
        }
        //cardObjects = Utility.GetAtPath<GameObject>("Prefabs/CardsColection/");
    }

    void CreateCard(Card card)
    {
        // Instantiate a new card based on the cardPrefab
        GameObject newCard = Instantiate(cardPrefab);
        // Parent the new card to the container
        newCard.hideFlags = HideFlags.HideInHierarchy;
        // Add the container to the list
        if (card.IsSpecial)
        {
            newCard.AddComponent<SpecjalCard>();
        }
        else
        {
            newCard.AddComponent<BaseCard>();
        }

        CardObject cardObject = newCard.GetComponent<CardObject>();
        cardObject.setCardValues(card);
        newCard.name = card.Name;
        cardObjects.Add(newCard);
       
    }

    public GameObject getRandom()
    {
        int index = Random.Range(0, cardObjects.Count);
        
        Debug.Log(cardObjects[index]);

        //usunac karte z talii (moze kiedys)

        return cardObjects[index];
    }
}
