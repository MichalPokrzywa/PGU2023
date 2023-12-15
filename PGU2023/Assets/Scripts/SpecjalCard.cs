using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a special card object that inherits from the CardObject class.
/// </summary>
public class SpecjalCard : CardObject
{
    /// <summary>
    /// Overrides the PowerUp method from the base class to increase the interest and functionality of the card.
    /// </summary>
    public override void PowerUp()
    {
        interest += cost / 10;
        funtionality += cost / 10;
    }

    /// <summary>
    /// Overrides the UpdateValue method from the base class to update the values of the card.
    /// </summary>
    /// <param name="starTuple">A tuple containing the starting values of the card.</param>
    /// <returns>A tuple containing the updated values of the card.</returns>
    public override (int updatedValue, int updatedCost, int updatedInterest, int updatedFuntionality) UpdateValue((int startValue, int startCost, int startInterest, int startFuntionality) starTuple)
    {
        int updatedValue = starTuple.startValue * 2;
        int updatedCost = starTuple.startCost * 2;
        int updatedInterest = starTuple.startInterest * 2;
        int updatedFuntionality = starTuple.startFuntionality * 2;

        return (updatedValue, updatedCost, updatedInterest, updatedFuntionality);
    }

    /// <summary>
    /// Overrides the IsCardSpecial method from the base class to indicate that this card is special.
    /// </summary>
    /// <returns>True, indicating that this card is special.</returns>
    public override bool IsCardSpecial()
    {
        return true;
    }
}
