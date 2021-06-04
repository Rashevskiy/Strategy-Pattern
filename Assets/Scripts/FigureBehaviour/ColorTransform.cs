using UnityEngine;
using System.Collections;
public class ColorTransform : ITransform
{
    private Transform figure;
    private Color target;
    private float speed;
    public ColorTransform(Transform figure, float[] colorTargetData, float speed){
        this.figure = figure;
        this.target = new Color(colorTargetData[0], colorTargetData[1], colorTargetData[2]);
        this.speed = speed;
    }
    public void SetStartTransform(float[] colorStartData)
    {
        throw new System.NotImplementedException();
    }


    public IEnumerator Translate()
    {
        throw new System.NotImplementedException();
    }
    public BehaviorStruct ToStruct()
    {
        throw new System.NotImplementedException();
        
    }
}