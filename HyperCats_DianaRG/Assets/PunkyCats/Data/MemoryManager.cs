using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using DinoFramework;
using PunkyCats.Code;

public class MemoryManager : MonoBehaviour
{
    public AssetReference_Data assetReferenceData;
    private List<Save_AssetSO> savesList;

    public string path_SaveAssets;
    // Start is called before the first frame update
    void Start()
    {
        path_SaveAssets = Application.streamingAssetsPath + "/SaveAssetsData.json";
        savesList = new List<Save_AssetSO>();
        
        if (!File.Exists( path_SaveAssets))
        {
            CreateSaveAssetsJSON();
            Debug.Log("create json");
        }
        else
        {
            string json = File.ReadAllText(path_SaveAssets);
            LoadSaveAssets(json);
            Debug.Log("Load Json");

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

    void LoadSaveAssets(string json)
    {
        Save_AssetSO[] saves = JsonHelper.FromJson<Save_AssetSO>(json);

        // print(saves);
        for (int i = 0; i < saves.Length; i++)
        {
            print(saves[i]._id);
        }
        // foreach (Asset_SO assetSo in assetReferenceData.AllAssets)
        // {
        // }
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


