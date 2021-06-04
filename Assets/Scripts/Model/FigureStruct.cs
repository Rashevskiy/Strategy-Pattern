using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public struct JsonDataStruct{
    public FigureStruct[] objects;
}
[System.Serializable]
public struct FigureStruct
{
    public string type;
    public BehaviorStruct[] behaviours;

}

[System.Serializable]
public struct BehaviorStruct{

    public string type;

    public float[] from;

    public float[] to;

    public float time;

    
}





