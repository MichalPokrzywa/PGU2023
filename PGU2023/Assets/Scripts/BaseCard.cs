using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCard : CardObject
{

    public override void PowerUp()
    {
        //moc podstawowej karty
    }
    public override (int updatedValue, int updatedCost, int updatedInterest, int updatedFuntionality) UpdateValue((int startValue, int startCost, int startInterest, int startFuntionality) starTuple)
    {
        return starTuple;
    }

    public override bool IsCardSpecial()
    {
        return false;
    }
}
