using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecjalCard : CardObject
{
    // Start is called before the first frame update
    public override void PowerUp()
    {
        averageFloors += apartments / 10;
        tree += apartments / 10;
    }
    public override (int updatedValue, int updatedCost, int updatedInterest, int updatedFuntionality) UpdateValue((int startValue, int startCost, int startInterest, int startFuntionality) starTuple)
    {
        int updatedValue = starTuple.startValue * 2;
        int updatedCost = starTuple.startCost * 2;
        int updatedInterest = starTuple.startInterest * 2;
        int updatedFuntionality = starTuple.startFuntionality * 2;

        return (updatedValue, updatedCost, updatedInterest, updatedFuntionality);
    }

    public override bool IsCardSpecial()
    {
        return true;
    }
}
