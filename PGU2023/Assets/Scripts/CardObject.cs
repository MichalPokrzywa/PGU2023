using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enum defining different card symbols.
/// </summary>
public enum Symbol
{
    Club,
    Diamond,
    Hearts,
    Spades
}

/// <summary>
/// Base class for all card objects in the game.
/// </summary>
public class CardObject : MonoBehaviour
{
    [SerializeField] protected Symbol symbol;
    [SerializeField] protected int value;

    // Parameters     
    [SerializeField] protected int cost;
    [SerializeField] protected int interest;
    [SerializeField] protected int funtionality;
    [SerializeField] GameObject gameObjectModel;

    public bool isDragged = false;

    private bool buildOnce = true;

    private float initialYPosition;
    private Plane dragPlane;
    private Camera mainCamera;
    private Vector3 targetPosition;
    private int handIndex;

    private void Start()
    {
        mainCamera = Camera.main;
        initialYPosition = transform.position.y;

        // Define the plane that represents the desired drag plane
        dragPlane = new Plane(Vector3.up, new Vector3(transform.position.x, initialYPosition, transform.position.z));
    }

    private void OnMouseDrag()
    {
        if (GameManager.instance.isInWalkMode) return;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        float enter;
        isDragged = true;

        // Raycast to find the intersection with the drag plane
        if (dragPlane.Raycast(ray, out enter))
        {
            // Calculate the world position of the intersection point
            targetPosition = ray.GetPoint(enter);

            // Ensure the object maintains its initial Y position
            targetPosition.y = initialYPosition;

            // Interpolate the position of the object to the target position
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);
        }
    }

    private void OnMouseUp()
    {
        isDragged = false;
    }

    /// <summary>
    /// Checks if the card is special.
    /// </summary>
    /// <returns>True if the card is special, otherwise false.</returns>
    public virtual bool IsCardSpecial()
    {
        return false;
    }

    /// <summary>
    /// Retrieves the tuple containing the card's values.
    /// </summary>
    /// <returns>A tuple containing the card's values.</returns>
    public (int startValue, int startCost, int startInterest, int startFuntionality) GetValueTuple()
    {
        return (value, cost, interest, funtionality);
    }

    /// <summary>
    /// Sets the values of the card based on a Card object.
    /// </summary>
    /// <param name="cardFile">The Card object containing the values.</param>
    public void SetCardValues(Card cardFile)
    {
        symbol = Enum.Parse<Symbol>(cardFile.Symbol);
        value = cardFile.Value;
        cost = cardFile.Cost;
        interest = cardFile.Interest;
        funtionality = cardFile.Functionality;
        gameObjectModel = Resources.Load<GameObject>(cardFile.GameObjectPath);
    }

    /// <summary>
    /// Powers up the card.
    /// </summary>
    public virtual void PowerUp()
    {
        // Implementation details for powering up the card
    }

    /// <summary>
    /// Updates the card values based on the provided tuple.
    /// </summary>
    /// <param name="starTuple">Tuple containing start values.</param>
    /// <returns>A tuple containing updated values.</returns>
    public virtual (int updatedValue, int updatedCost, int updatedInterest, int updatedFuntionality) UpdateValue((int startValue, int startCost, int startInterest, int startFuntionality) starTuple)
    {
        return (0, 0, 0, 0);
    }

    /// <summary>
    /// Builds the card.
    /// </summary>
    /// <returns>True if the card is built successfully, otherwise false.</returns>
    public virtual bool Build()
    {
        if (buildOnce)
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            Instantiate(gameObjectModel, this.gameObject.transform.parent);
            buildOnce = false;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Sets the index for the card.
    /// </summary>
    /// <param name="index">The index to set.</param>
    public void setIndex(int index)
    {
        handIndex = index;
    }

    /// <summary>
    /// Gets the index of the card.
    /// </summary>
    /// <returns>The index of the card.</returns>
    public int getIndex()
    {
        return handIndex;
    }
}
