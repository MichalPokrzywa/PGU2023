using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndWriter : MonoBehaviour
{
    [SerializeField] EndMoveData data;
    [SerializeField] MoveData startdata;

    public void StoreData(int cost, int value, float intrest, int functionality)
    {
        data.cost = cost;
        data.value = value;
        data.intrest = intrest;
        data.functionality = functionality;
    }
}
