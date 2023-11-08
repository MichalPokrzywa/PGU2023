using System;
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
        if(GameManager.instance.isInWalkMode) return;
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

    public virtual bool IsCardSpecial()
    {
        return false;
    }
    public (int startValue, int startCost, int startInterest, int startFuntionality) GetValueTuple()
    {
        return (value, cost, interest, funtionality);
    }
    public void SetCardValues(Card cardFile)
    {
        symbol = Enum.Parse<Symbol>(cardFile.Symbol);
        value = cardFile.Value;
        cost = cardFile.Cost;
        interest = cardFile.Interest;
        funtionality = cardFile.Functionality;
        gameObjectModel = Resources.Load<GameObject>(cardFile.GameObjectPath);
    }
    public virtual void PowerUp()
    {
        //umiejka karty
    }

    public virtual (int updatedValue, int updatedCost, int updatedInterest, int updatedFuntionality) UpdateValue((int startValue, int startCost, int startInterest, int startFuntionality) starTuple)
    {
        return (0, 0, 0, 0);
    }
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

    public void setIndex(int index)
    {
        handIndex = index;
    }

    public int getIndex()
    {
        return handIndex;
    }


}
