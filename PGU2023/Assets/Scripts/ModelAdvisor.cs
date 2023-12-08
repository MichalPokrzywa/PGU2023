using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

/// <summary>
/// Represents a model advisor in the game.
/// </summary>
public class ModelAdvisor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        transform.localScale = new Vector3(3f, 3f, 3f);
        this.AddComponent<BoxCollider>();
    
    }

}
