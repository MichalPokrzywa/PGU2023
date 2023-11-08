using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BombManager : MonoBehaviour
{

    public bool isDragged = false;
    private float initialYPosition;
    private Plane dragPlane;
    private Camera mainCamera;
    private Vector3 targetPosition;
    [SerializeField] int bombCount;

    private void Start()
    {
        mainCamera = Camera.main;
        initialYPosition = transform.position.y;

        bombCount *= 2;

        // Define the plane that represents the desired drag plane
        dragPlane = new Plane(Vector3.up, new Vector3(transform.position.x, initialYPosition, transform.position.z));
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<CardObject>() == null) return;

        CardObject card = collision.gameObject.GetComponent<CardObject>();
        HandManager.instance.removeCard(card.gameObject);
        card.gameObject.GetComponent<MeshRenderer>().enabled = false;
        GameObject gameCard = DeckManager.instance.getRandom();
        HandManager.instance.add(gameCard);

        bombCount--;
        if (bombCount <= 0)
        {
            this.gameObject.SetActive(false);
        }
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
}
