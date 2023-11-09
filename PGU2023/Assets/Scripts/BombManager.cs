using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    private static BombManager _instance;
    public static BombManager instance => _instance;


    [SerializeField] int bombCount;
    private Vector3 startPosition;

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
        //card.gameObject.SetActive(false);
        Destroy(card.gameObject);
        

        bombCount--;
        if (bombCount <= 0)
        {
            this.gameObject.SetActive(false);
        }

        transform.position = startPosition;
    }



    public int getBombCount()
    {
        return bombCount;
    }
}
