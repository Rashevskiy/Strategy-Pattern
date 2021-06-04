using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public static class ResourceHelper{
    public static JsonDataStruct LoadFiguresFromJson(string fileName)
    {
        string json = Resources.Load<TextAsset>(fileName).text;
        return JsonUtility.FromJson<JsonDataStruct>(json);
    }

    public static GameObject LoadPrefabFromResources(string name){
      GameObject prefab = Resources.Load<GameObject>("Figures/" + name);
      return prefab;
    }
    public static void SaveFiguresToJson(List<Figure> figures, string fileName){
      JsonDataStruct jsonStruct = new JsonDataStruct();
      jsonStruct.objects = new FigureStruct[figures.Count];

      for(int i = 0; i < jsonStruct.objects.Length; i++){
        jsonStruct.objects[i] = figures[i].ToStruct();
      }

     var json = JsonUtility.ToJson(jsonStruct);
     string path = Application.dataPath + "/Resources/" + fileName + ".json";

     if(File.Exists(path)){
          File.WriteAllText(path,json);
          AssetDatabase.Refresh();
     }
     else
     {
         return;
     }
     
    }
}