using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ResourceType {
    Tree=1,
    FoodField=2,
    Rocks=3,
    Metal = 4
}

public class Resource : MonoBehaviour
{
    public string _name;
    public string _description;
    public ResourceType _type;
}
