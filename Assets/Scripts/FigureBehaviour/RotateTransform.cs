
using System.Collections;
using UnityEngine;
public class RotateTransform : ITransform
{
    private Transform figure;
    private Vector3 target;
    private float time;
    public RotateTransform(Transform figure, float[] vectorTargetData, float time){
        this.figure = figure;
        this.target = new Vector3(vectorTargetData[0],vectorTargetData[1],vectorTargetData[2]);
        this.time = time;
    }
    public void SetStartTransform(float[] vectorStartData)
    {
        figure.rotation = Quaternion.Euler(vectorStartData[0],vectorStartData[1],vectorStartData[2]); 
    }


    public IEnumerator Translate()
    {
        var bufferTime = time;
        var angle = 1f;

        var test = figure.GetComponent<Figure>().Type;
        while(angle > 0.1f){
            figure.rotation = Quaternion.Lerp(figure.rotation, Quaternion.Euler(target),Time.deltaTime * 6.5f / bufferTime);
            angle = Quaternion.Angle(figure.rotation,Quaternion.Euler(target));
            time -= Time.deltaTime;
            yield return null;
        } 
        
        
    }
    public BehaviorStruct ToStruct()
    {
        var behaviorStruct = new BehaviorStruct();
        behaviorStruct.type = "rotate";
        behaviorStruct.from = new float[]{figure.rotation.x,figure.rotation.y,figure.rotation.z};
        behaviorStruct.to = new float[] { target.x, target.y, target.z};
        behaviorStruct.time = time;
        return behaviorStruct;
    }
}