using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour{
    [SerializeField] private string jsonFileName;
    private List<Figure> figures;

    void Start(){
      InstanceAllFigures();
      TranslateAllFigures();
    }

    public void InstanceAllFigures(){
      int objCount = 0;
      FigureStruct[] figuresData = ResourceHelper.LoadFiguresFromJson(jsonFileName).objects;
      figures = new List<Figure>();
      foreach(var figureData in figuresData){
        GameObject prefab = ResourceHelper.LoadPrefabFromResources(figureData.type);
        if(!prefab) continue;
        Figure newFigure = Instantiate(prefab.gameObject).GetComponent<Figure>();
        newFigure.Init(figureData.behaviours,figureData.type);
        figures.Add(newFigure);

        newFigure.gameObject.name = objCount.ToString();
        objCount++;
      }
    }

    public void TranslateAllFigures(){
      foreach(Figure figure in figures){
        figure.Translate();
      }
    }
    public void SaveToJson(string jsonSave){
      ResourceHelper.SaveFiguresToJson(figures,jsonSave);
    }
    public void NextScene(string nextScene){
      SceneManager.LoadScene(nextScene);
    }


}