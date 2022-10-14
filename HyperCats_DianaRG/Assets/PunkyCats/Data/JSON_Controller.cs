using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using DinoFramework;
using PunkyCats.Code;

public class JSON_Controller : MonoBehaviour
{
    [Header("Datas")]
    public AssetReference_Data assetReferenceData;
    public Cat_Data catData;
    public List<Currency_SO> currenciesData;

   [HideInInspector] public List<Asset_SO> LoadAssets;
    private string path_SaveAssets;
    private string path_SaveCatData;
    private string path_SaveCurrencyData;
    
    private string JSON_Assets; 
    private string JSON_CatData; 
    private string JSON_CurrencyData; 
    private List<Save_AssetSO> _savesAssetsList;
    private List<Save_CurrencySO> _savesCurrencyList;
    
    public Action OnFinishedLoadingJSONS;

    public string MyCatDataJSON
    {
        get => JSON_CatData;
    }
    
    
    void Awake()
    {
        Debug.Log("Se llama awake JSON");
        InitializeJSONS();        
    }

    private void OnEnable()
    {
    }

    private void InitializeJSONS()
    {
#if UNITY_EDITOR
        Debug.Log("Es Unity Editor");

        path_SaveAssets = Application.streamingAssetsPath + "/SaveAssetsData.json";
        path_SaveCatData = Application.streamingAssetsPath + "/SaveCatData.json";
        path_SaveCurrencyData = Application.streamingAssetsPath + "/SaveCurrencyData.json";
#endif
        
#if PLATFORM_ANDROID
        Debug.Log("Es android device");
        path_SaveAssets = Application.persistentDataPath + "/SaveAssetsData.json";
        path_SaveCatData = Application.persistentDataPath + "/SaveCatData.json";
        path_SaveCurrencyData = Application.persistentDataPath + "/SaveCurrencyData.json";

#endif
        Debug.Log("Path Save Assets: " + path_SaveAssets);
        
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

        if (!File.Exists(path_SaveCurrencyData))
        {
            CreateSaveCurrencyJSON();
        }
        else
        {
            string json_currencyData = File.ReadAllText(path_SaveCurrencyData);
            JSON_CurrencyData = json_currencyData;
            LoadSaveCurrency(JSON_CurrencyData);
            
        }
        OnFinishedLoadingJSONS?.Invoke();
    }
    public void CreatSaveCatDataJSON()
    {
        string path;
#if UNITY_EDITOR
        path = Application.streamingAssetsPath + "/SaveCatData.json";
#endif
        
#if PLATFORM_ANDROID
         path = Application.persistentDataPath + "/SaveCatData.json";
#endif

        string[] catDataAssetsIDS = { catData.catSkin_ID, catData.catEyes_ID, "","","","","", ""};
        string catDataReference = JsonHelper.ToJson(catDataAssetsIDS, true);
        File.WriteAllText(path,catDataReference);
    }
    public void CreateSaveAssetsJSON()
    {
        string path;
#if UNITY_EDITOR
        path = Application.streamingAssetsPath + "/SaveAssetsData.json";
        #endif

#if PLATFORM_ANDROID
        path = Application.persistentDataPath + "/SaveAssetsData.json";
        
#endif
        
        _savesAssetsList = new List<Save_AssetSO>();
        foreach (Asset_SO assetSo in assetReferenceData.AllAssets)
        {
            Save_AssetSO saveAsset = new Save_AssetSO( assetSo.ID, assetSo.IsUnlocked);
            _savesAssetsList.Add(saveAsset);
            print(saveAsset._id);
        }
        string assetReference = JsonHelper.ToJson(_savesAssetsList.ToArray(), true);
        print(assetReference);

        File.WriteAllText(path, assetReference);
    }

    public void CreateSaveCurrencyJSON()
    {
        _savesCurrencyList = new List<Save_CurrencySO>();
        foreach (Currency_SO currencySo in currenciesData)
        {
            Save_CurrencySO saveCurrency = new Save_CurrencySO(currencySo.ID, currencySo.SavedCurrency);
            _savesCurrencyList.Add(saveCurrency);
            print(saveCurrency);
        }

        string currencyData = JsonHelper.ToJson(_savesCurrencyList.ToArray(), true);
        print(currencyData);
        
        File.WriteAllText(path_SaveCurrencyData, currencyData);
    }

    
    public void LoadCatDataJSON(string json)
    {
        
        string[] catDataJSON = JsonHelper.FromJson<string>(json);

        Asset_SO findableAsset;
        
        foreach (Asset_SO asset in LoadAssets)
        {
            for (int i = 0; i < catDataJSON.Length; i++)
            {
                string ID = catDataJSON[i];
                if (String.IsNullOrEmpty(ID)) i++;
                
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

    public void LoadSaveCurrency(string json)
    {
        Save_CurrencySO[] savesCurrencies = JsonHelper.FromJson<Save_CurrencySO>(json);
        for (int i = 0; i < savesCurrencies.Length; i++)
        {
            currenciesData[i].ID = savesCurrencies[i]._id;
            currenciesData[i].SavedCurrency = savesCurrencies[i]._currencyAmount;
        }

    }
    public void SetCatDataChanges(string json)
    {
        string path;
#if UNITY_EDITOR
         path = Application.streamingAssetsPath + "/SaveCatData.json";
#endif
#if PLATFORM_ANDROID
        path = Application.persistentDataPath + "/SaveCatData.json";
#endif
        
        string[] catDataAssetsIDS = { 
            catData.catSkin_ID,
            catData.catEyes_ID,
            catData.catPants_ID,
            catData.catChest_ID,
            catData.catHead_ID,
            catData.catHair_ID,
            catData.catTail_ID,
            catData.catShoes_ID
        };


        string catDataReference = JsonHelper.ToJson(catDataAssetsIDS, true); 

        File.WriteAllText(path,catDataReference);

    }
    public void ChangeAssetValues(string assetID, bool newValue)
    {

        string path;

#if UNITY_EDITOR
        path = Application.streamingAssetsPath + "/SaveAssetsData.json";
#endif

#if PLATFORM_ANDROID
        path = Application.persistentDataPath + "/SaveAssetsData.json";
#endif
        Save_AssetSO[] saves = JsonHelper.FromJson<Save_AssetSO>(JSON_Assets);

        for (int i = 0; i < saves.Length; i++)
        {
            if (saves[i]._id == assetID)
            {
                saves[i]._isUnlocked = newValue;
            }
        }
        
        string assetReference = JsonHelper.ToJson(saves, true);
        File.WriteAllText(path,assetReference);
        
    }

    public void UpdateCurrency(string currencyID, int newAmount)
    {
        string path;

#if UNITY_EDITOR
        path = Application.streamingAssetsPath + "/SaveCurrencyData.json";
#endif
#if PLATFORM_ANDROID
         path = Application.persistentDataPath + "/SaveCurrencyData.json";
#endif
        string json_currencyData = File.ReadAllText(path);
        Save_CurrencySO[] saveCurrency = JsonHelper.FromJson<Save_CurrencySO>(json_currencyData);
        for (int i = 0; i < saveCurrency.Length; i++)
        {
            if (saveCurrency[i]._id == currencyID)
            {
                saveCurrency[i]._currencyAmount = newAmount;
            }
        }

        string currencyData = JsonHelper.ToJson(saveCurrency, true);
        File.WriteAllText(path, currencyData);
        print("Se actauliza currency json");
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


