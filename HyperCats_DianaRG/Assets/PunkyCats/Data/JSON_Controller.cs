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
    
    private string JSON_Assets; 
    private string JSON_CatData; 
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
            string json_aseets = File.ReadAllText(path_SaveAssets);
            JSON_Assets = json_aseets;
            LoadSaveAssets(JSON_Assets);
            Debug.Log("Load Json_Assets");

        }

        if (!File.Exists(path_SaveCatData))
        {
            CreatSaveCatDataJSON();
        }
        else
        {
            string json_catData = File.ReadAllText(path_SaveCatData);
            JSON_CatData = json_catData;
            LoadCatDataJSON(JSON_CatData);
            Debug.Log("Load Json_Cat");
            
        }
        
    }

    void CreatSaveCatDataJSON()
    {
        string path = Application.streamingAssetsPath + "/SaveCatData.json";

        string[] catDataAssetsIDS = { catData.catSkin_Data.ID, catData.catEyes_Data.ID , "","","","","", ""};
        string catDataReference = JsonHelper.ToJson(catDataAssetsIDS, true);
        File.WriteAllText(path,catDataReference);
    }

    void LoadCatDataJSON(string json)
    {
        string[] catDataJSON = JsonHelper.FromJson<string>(json);

        Asset_SO findableAsset;
        
        foreach (Asset_SO asset in LoadAssets)
        {
            for (int i = 0; i < catDataJSON.Length; i++)
            {
                if (catDataJSON[i] == asset.ID)
                {
                    findableAsset = asset;
                    switch (findableAsset.AssetType)
                    {
                        case AssetType.Skin:
                            catData.catSkin_Data = findableAsset;
                            break;
                        case AssetType.Eyes:
                            catData.catEyes_Data = findableAsset;
                            break;
                        case AssetType.Hair:
                            catData.catHair_Data = findableAsset;
                            break;
                        case AssetType.Head:
                            catData.catHead_Data = findableAsset;
                            break;
                        case AssetType.Chest:
                            catData.catChest_Data = findableAsset;
                            break;
                        case AssetType.Pants:
                            catData.catPants_Data = findableAsset;
                            break;
                        case AssetType.Tail:
                            catData.catTail_Data = findableAsset;
                            break;
                        case AssetType.Shoes:
                            catData.catShoes_Data = findableAsset;
                            break;
                    }
                }
            } 
        }
        
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
        Save_AssetSO[] saves = JsonHelper.FromJson<Save_AssetSO>(JSON_Assets);

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


