using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : Worker
{
    public override void DoWork()
    {
        base.DoWork();
    }

    public override void Walk(Resource target)
    {
        if(target._type==ResourceType.Metal || target._type == ResourceType.Rocks)
        {
            SetResource(target);
        }
        
    }
}
