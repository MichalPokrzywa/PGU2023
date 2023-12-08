using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Manages the behavior of bombs in the game.
/// </summary>
public class BombManager : MonoBehaviour
{
    private static BombManager _instance;
    public static BombManager instance => _instance;

    [SerializeField] int bombCount;
    private Vector3 startPosition;

    /// <summary>
    /// Initializes the BombManager instance.
    /// </summary>
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

    private void Start()
    {
        startPosition = transform.position;
    }

    /// <summary>
    /// Handles the collision with other objects.
    /// </summary>
    /// <param name="collision">The collision data.</param>
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponent<CardObject>() == null)
        {
            return;
        }
        if (collision.gameObject.GetComponent<CardObject>().isDragged == true)
        {
            return;
        }
        CardObject card = collision.gameObject.GetComponent<CardObject>();
        HandManager.instance.removeCard(card.gameObject);
        Destroy(card.gameObject);

        bombCount--;
        if (bombCount <= 0)
        {
            this.gameObject.SetActive(false);
        }

        transform.position = startPosition;
    }

    /// <summary>
    /// Gets the current bomb count.
    /// </summary>
    /// <returns>The bomb count.</returns>
    public int getBombCount()
    {
        return bombCount;
    }
}
