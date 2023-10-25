using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecjalCard : CardObject
{
    // Start is called before the first frame update
    public override void PowerUp()
    {
        interest += cost / 10;
        funtionality += cost / 10;
    }
}
