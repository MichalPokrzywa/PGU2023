using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a base card object.
/// </summary>
public class BaseCard : CardObject
{
    /// <summary>
    /// Powers up the base card.
    /// </summary>
    public override void PowerUp()
    {
        // Implementation details for powering up the base card
    }

    /// <summary>
    /// Updates the value of the base card.
    /// </summary>
    /// <param name="starTuple">Tuple containing start values.</param>
    /// <returns>A tuple containing updated values.</returns>
    public override (int updatedValue, int updatedCost, int updatedInterest, int updatedFuntionality) UpdateValue((int startValue, int startCost, int startInterest, int startFuntionality) starTuple)
    {
        return starTuple;
    }

    /// <summary>
    /// Checks if the base card is special.
    /// </summary>
    /// <returns>True if the card is special, otherwise false.</returns>
    public override bool IsCardSpecial()
    {
        return false;
    }
}
