using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumer : MonoBehaviour
{
    [SerializeField] MoveData data;

    public MoveData GetData()
    {
        return data;
    }
}
