using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Symbol
{
    Hearts,
    Diamond,
    Club,
    Spades
}
public class CardObject : MonoBehaviour
{
    //parameters     
    [SerializeField] protected Symbol symbol;
    [SerializeField] protected int cardValue;
    [SerializeField] protected int cost;
    [SerializeField] protected float intensityDev;
    [SerializeField] protected float bioSurface;
    [SerializeField] protected float areaSurface;
    [SerializeField] protected int apartments;
    [SerializeField] protected int averageFloors;
    [SerializeField] protected int tree;
    [SerializeField] GameObject gameObjectModel;
    [SerializeField] Material cardMaterial;

    public bool isDragged = false;

    private bool buildOnce = true;

    private float initialYPosition;
    private Plane dragPlane;
    private Camera mainCamera;
    private Vector3 targetPosition;
    private int handIndex;
    private Card card;

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
        return (cost, apartments, averageFloors, tree);
    }
    public void SetCardValues(Card cardFile)
    {
        card = cardFile;
        symbol = Enum.Parse<Symbol>(cardFile.Symbol);
        cardValue = cardFile.Value;
        cost = cardFile.Cost;
        apartments = cardFile.NumberOfApartments;
        averageFloors = cardFile.AverageNumberOfFloors;
        tree = cardFile.TreeCount;
        intensityDev = cardFile.DevelopmentIntensity;
        bioSurface = cardFile.BiodegradableSurfacePercentage;
        areaSurface = cardFile.SurfaceAreaPercentage;
        gameObjectModel = Resources.Load<GameObject>(cardFile.GameObjectPath);
        cardMaterial = Resources.Load<Material>(cardFile.MaterialPath);
        this.GetComponent<MeshRenderer>().material = cardMaterial;
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

    public Texture2D GetCardTexture()
    {
        return (Texture2D)cardMaterial.GetTexture("_MainTex2");
    }

    public Card GetCardValues()
    {
        return card;
    }


}
