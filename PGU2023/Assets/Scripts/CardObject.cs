using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Symbol
{
    Club,
    Diamond,
    Hearts,
    Spades
}
public class CardObject : MonoBehaviour
{
    [SerializeField] protected Symbol symbol;
    [SerializeField] protected int value;
                     
    //parameters     
    [SerializeField] protected int cost;
    [SerializeField] protected int interest;
    [SerializeField] protected int funtionality;
    [SerializeField] GameObject gameObjectModel;

    public virtual void PowerUp()
    {
        //umiejka karty
    }

    public virtual void Build()
    {
        //stawianie budynku
    }

}
