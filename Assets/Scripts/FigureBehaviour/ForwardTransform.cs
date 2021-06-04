

using System.Collections;
using UnityEngine;

public class ForwardTransform : ITransform
{
    private Transform figure;
    private Vector3 target;
    private float time;
    public ForwardTransform(Transform figure, float[] vectorTargetData, float time){
        this.figure = figure;
        this.target = new Vector3(vectorTargetData[0],vectorTargetData[1],vectorTargetData[2]);
        this.time = time;
    }
    public void SetStartTransform(float[] vectorStartData)
    {
        figure.position = new Vector3(vectorStartData[0], vectorStartData[1], vectorStartData[2]);
    }

    
    public BehaviorStruct ToStruct()
    {
        var behaviorStruct = new BehaviorStruct();
        behaviorStruct.type = "move";
        behaviorStruct.from = new float[]{figure.position.x,figure.position.y,figure.position.z};
        behaviorStruct.to = new float[] {target.x,target.y,target.z};
        behaviorStruct.time = time;
        return behaviorStruct;
    }

    public IEnumerator Translate()
    {
         var bufferTime = time;   
        while(Vector3.Distance(figure.position, target) > 0.1f){
            figure.position = Vector3.LerpUnclamped(figure.position,target, Time.deltaTime * 6.5f / bufferTime);
            time -= Time.deltaTime;
            
            yield return null;
        }
    }
}