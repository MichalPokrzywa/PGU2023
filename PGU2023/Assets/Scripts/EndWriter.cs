using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for storing data related to the end of the game.
/// </summary>
public class EndWriter : MonoBehaviour
{
    [SerializeField] EndMoveData data;
    [SerializeField] MoveData startdata;

    /// <summary>
    /// Stores the given data related to the end of the game.
    /// </summary>
    /// <param name="cost">The cost of the end.</param>
    /// <param name="value">The value of the end.</param>
    /// <param name="intrest">The interest of the end.</param>
    /// <param name="functionality">The functionality of the end.</param>
    public void StoreData(int cost, int value, int intrest, int functionality)
    {
        data.cost = cost;
        data.value = value;
        data.intrest = intrest;
        data.functionality = functionality;
    }
}
