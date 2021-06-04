using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Figure : MonoBehaviour{

    public Dictionary<ITransform,Coroutine> behaviours {get;private set;}
    public string Type {get; private set;}
    private Coroutine translateRoutine;
    public void Init(BehaviorStruct[] behavioursData, string figureType){
       this.Type = figureType;
       behaviours = new Dictionary<ITransform,Coroutine>();
       foreach(var behStruct in behavioursData){
         ITransform behaviour;
         switch(behStruct.type){
            case "rotate": behaviour = new RotateTransform(this.transform,behStruct.to,behStruct.time); break;
            case "color": behaviour = new ColorTransform(this.transform,behStruct.to,behStruct.time); break;
            default: behaviour = new ForwardTransform(this.transform, behStruct.to,behStruct.time); break;
         }
         behaviour.SetStartTransform(behStruct.from);
         behaviours.Add(behaviour, null);
      }
      
    }

    /// <summary>
    /// Активириует все поведения и сохраняет ссылки на рутины
    /// </summary>
    public void Translate(){
      foreach(var behavior in behaviours.Keys.ToList()){
        behaviours[behavior] = StartCoroutine(behavior.Translate());
      } 
    }

    public void StopAllTranslates(){
      behaviours.Values.ToList().ForEach(delegate(Coroutine routine){
        if(routine != null) StopCoroutine(routine);
      });

    }

    public FigureStruct ToStruct(){
      var figureStruct = new FigureStruct();
      figureStruct.type = Type;
      figureStruct.behaviours = new BehaviorStruct[behaviours.Count];
      int i = 0;
      foreach(var behaviour in behaviours.Keys.ToList()){
        figureStruct.behaviours[i] = behaviour.ToStruct();
        i++;
      }
      return figureStruct;
    }
}