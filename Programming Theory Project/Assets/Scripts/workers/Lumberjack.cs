using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lumberjack : Worker // INHERITANCE
{
    
    public override void DoWork()
    {
        base.DoWork();
    }

    public override void Walk(Resource target) // POLYMORPHISM
    {
        if (target._type == ResourceType.Tree)
        {
            SetResource(target);
        }
        else
        {
            ShowText();
        }
    }
}
