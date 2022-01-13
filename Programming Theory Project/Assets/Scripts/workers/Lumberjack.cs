using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lumberjack : Worker
{
    
    public override void DoWork()
    {
        base.DoWork();
    }

    public override void Walk(Resource target)
    {
        if (target._type == ResourceType.Tree)
        {
            SetResource(target);
        }

    }
}
