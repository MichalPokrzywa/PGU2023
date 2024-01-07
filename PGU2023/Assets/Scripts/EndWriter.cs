using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndWriter : MonoBehaviour
{
    [SerializeField] EndMoveData data;
    [SerializeField] MoveData startdata;

    public void StoreData(int cost)
    {
        data.endScore = cost;
    }
}
