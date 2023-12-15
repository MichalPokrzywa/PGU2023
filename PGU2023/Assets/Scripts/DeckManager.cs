using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// Manages the deck of cards in the game.
/// </summary>
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

    /// <summary>
    /// Loads the card game objects from a card collection.
    /// </summary>
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

    /// <summary>
    /// Creates a new card game object based on the given card data.
    /// </summary>
    /// <param name="card">The card data.</param>
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

    /// <summary>
    /// Returns a random card game object from the deck.
    /// </summary>
    /// <returns>A random card game object.</returns>
    public GameObject getRandom()
    {
        int index = Random.Range(0, cardObjects.Count);
        
        Debug.Log(cardObjects[index]);

        //usunac karte z talii (moze kiedys)

        return cardObjects[index];
    }
}
