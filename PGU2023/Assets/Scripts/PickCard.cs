using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickCard : MonoBehaviour
{
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            if(GameManager.instance.isInWalkMode == true)
            {
                return;
            }
            HandManager.instance.chooseCard(this.gameObject);
        }
    }
}
