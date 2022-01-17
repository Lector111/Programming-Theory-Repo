using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : Worker
{
    public override void DoWork()
    {
        base.DoWork();
    }

    public override void Walk(Resource target)
    {
        if (target._type == ResourceType.FoodField)
        {
            SetResource(target);
        }
        else
        {
            ShowText();
        }
    }
}
