using System.Collections;
using System.IO;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public GameObject[] cardObjects;
    // Start is called before the first frame update
    void Start()
    {
        cardObjects = Utility.GetAtPath<GameObject>("Prefabs/Cards/");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadCards()
    {
        
    }

}
