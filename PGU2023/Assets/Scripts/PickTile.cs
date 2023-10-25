using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickTile : MonoBehaviour
{ 
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandManager.instance.moveCard(this.gameObject);
        }
    }
}
