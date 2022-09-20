using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using DinoFramework;
using PunkyCats.Code;

public class JSON_Controller : MonoBehaviour
{
    public AssetReference_Data assetReferenceData;
    public Cat_Data catData;
    
   [HideInInspector] public List<Asset_SO> LoadAssets;
   [HideInInspector] public string path_SaveAssets;
   [HideInInspector] public string path_SaveCatData;
    
    private string JSON; 
    private List<Save_AssetSO> savesList;

    void Awake()
    {
        path_SaveAssets = Application.streamingAssetsPath + "/SaveAssetsData.json";
        path_SaveCatData = Application.streamingAssetsPath + "/SaveCatData.json";
        savesList = new List<Save_AssetSO>();
        
        if (!File.Exists( path_SaveAssets))
        {
            CreateSaveAssetsJSON();
            Debug.Log("create json");
        }
        else
        {
            string json = File.ReadAllText(path_SaveAssets);
            JSON = json;
            LoadSaveAssets(JSON);
            Debug.Log("Load Json");

        }

        if (!File.Exists(path_SaveCatData))
        {
            CreatSaveCatDataJSON();
        }
        else
        {
            
        }
        
         // string json = File.ReadAllText(path);
        // CatObject catObject = JsonUtility.FromJson<CatObject>(json);
        // print(catObject.description);
        // CatObject[] catObjects; /*= new CatObject[2];
        // catObjects[0] = new CatObject("Garfield", 15, false, "Me cagan los lunes");
        // catObjects[1] = new CatObject("Scratchy", 4, true, "Muere!!!!!!");
        // string json = JsonHelper.ToJson(catObjects, true);
        //print(json);
        //File.WriteAllText(path, json);
        // string json = File.ReadAllText(path);
        // catObjects = JsonHelper.FromJson<CatObject>(json);
        // print (catObjects[1].name);



    }

    void CreatSaveCatDataJSON()
    {
        string path = Application.streamingAssetsPath + "/SaveAssetsData.json";

        string[] catDataAssetsIDS = { catData.catSkin_Data.ID, catData.catEyes_Data.ID , "","","","","", ""};

    }
    void CreateSaveAssetsJSON()
    {
        
        string path = Application.streamingAssetsPath + "/SaveAssetsData.json";
        foreach (Asset_SO assetSo in assetReferenceData.AllAssets)
        {
            Save_AssetSO saveAsset = new Save_AssetSO( assetSo.ID, assetSo.IsUnlocked);
            savesList.Add(saveAsset);
            print(saveAsset._id);
        }
        string assetReference = JsonHelper.ToJson(savesList.ToArray(), true);
        print(assetReference);

        File.WriteAllText(path, assetReference);
    }

    public void LoadSaveAssets(string json)
    {
        LoadAssets = new List<Asset_SO>();
       
        Save_AssetSO[] saves = JsonHelper.FromJson<Save_AssetSO>(json);

        for (int i = 0; i < saves.Length; i++)
        {
            assetReferenceData.AllAssets[i].ID = saves[i]._id;
            assetReferenceData.AllAssets[i].IsUnlocked = saves[i]._isUnlocked;
            
            LoadAssets.Add(assetReferenceData.AllAssets[i]);
        }
    }

    public void ChangeAssetValues(string assetID, bool newValue)
    {
        Save_AssetSO[] saves = JsonHelper.FromJson<Save_AssetSO>(JSON);

        for (int i = 0; i < saves.Length; i++)
        {
            if (saves[i]._id == assetID)
            {
                saves[i]._isUnlocked = newValue;
            }
        }
        
    }
  
}

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}


