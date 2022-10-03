using System;
using System.Collections.Generic;
using DinoFramework;
using UnityEngine;
using UnityEditor;
using PunkyCats.Code;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    public Action OnFinishedLoadingAssets;
    public AssetReferenceManager assetReferenceManager;

    [SerializeField] private Cat_Data _savedCatData;
    [SerializeField] private Asset_SO defaultSkin;
    [SerializeField] private Asset_SO defaultEyes;

    [SerializeField] private Currency_SO commonSavedSO;
    [SerializeField] private Currency_SO premiumSavedSO;
    [SerializeField] private Currency_SO gachaSavedSO;

    public Action OnUnlockAsset;

    public Cat_Data SavedCatData
    {
        get => _savedCatData;
        set => _savedCatData = value;
    }
    public int CommonCurrency
    {
        get { return commonSavedSO.SavedCurrency; }
        set { commonSavedSO.SavedCurrency = value; }
    }

    public int PremiumCurrency
    {
        get { return premiumSavedSO.SavedCurrency; }
        set { premiumSavedSO.SavedCurrency = value; }
    }

    public int GachaCurrency
    {
        get { return gachaSavedSO.SavedCurrency; }
        set { gachaSavedSO.SavedCurrency = value; }
    }
    
    [SerializeField] private List<Asset_SO> _loadAssets;
    [SerializeField] private List<Asset_SO> _unlockAssets;
    [SerializeField] private List<Asset_SO> _lockedAssets;
    
    public List<Asset_SO> UnlockedAssets
    {
        get => _unlockAssets;
    }
    public List<Asset_SO> LockedAssets
    {
        get => _lockedAssets;
    }
    
    private void OnEnable()
    {
        Instance = this;
    
    }

    void Awake()
    {
        Instance = this;
        
    }
    

    private void Start()
    {
        LoadAssets();
    }

    void LoadAssets()
    {
        _loadAssets = new List<Asset_SO>();
        _unlockAssets = new List<Asset_SO>();
        _lockedAssets = new List<Asset_SO>();
        // _loadAssets = assetReferenceManager.AssetReferenceData.AllAssets;

        JSON_Controller json = GetComponent<JSON_Controller>();
        _loadAssets = json.LoadAssets;
        
        
        foreach (Asset_SO  asset in _loadAssets)
        {
            if (asset.IsUnlocked)
            {
                _unlockAssets.Add(asset);
            }
            else
            {
                _lockedAssets.Add(asset);
            }
        }
        
        OnFinishedLoadingAssets?.Invoke();
    }

    public void RemoveAsset(int removeObject, List<Asset_SO> fromList)
    {
        Asset_SO removedAsset = fromList[removeObject];
        fromList.Remove(removedAsset);
        UpdateLists();
    }

    public void UpdateLists()
    {
        _unlockAssets = new List<Asset_SO>();
        _lockedAssets = new List<Asset_SO>();
        
        JSON_Controller json = GetComponent<JSON_Controller>();
        _loadAssets = json.LoadAssets;
        
        foreach (Asset_SO  asset in _loadAssets)
        {
            if (asset.IsUnlocked)
            {
                _unlockAssets.Add(asset);
            }
            else
            {
                _lockedAssets.Add(asset);
            }

        }
        Debug.Log("Unlocked Count = " + _unlockAssets.Count);
        Debug.Log("Locked Count = " + _lockedAssets.Count);
        
        OnUnlockAsset?.Invoke();
    }

    public void SaveCatDataChanges()
    {
        JSON_Controller json = GetComponent<JSON_Controller>();
        json.SetCatDataChanges(json.MyCatDataJSON);
    }
    
    public void SaveAssetChanges(string assetID, bool value)
    {
        JSON_Controller json = GetComponent<JSON_Controller>();
        json.ChangeAssetValues(assetID,value);
    }


    #region Editor
    
    public void ResetCatData()
    {
        Debug.Log("Reset Cat Data");

        _savedCatData.catEyes_Data = defaultEyes;
        _savedCatData.catSkin_Data = defaultSkin;
        _savedCatData.catShoes_Data = null;
        _savedCatData.catHair_Data = null;
        _savedCatData.catPants_Data = null;
        _savedCatData.catChest_Data = null;
        _savedCatData.catTail_Data = null;
        _savedCatData.catShoes_Data = null;
        _savedCatData.catHead_Data = null;

        JSON_Controller json = GetComponent<JSON_Controller>();
        json.CreatSaveCatDataJSON();
    }
    public void ResetAllAssets()
    {
        Debug.Log("Reset Assets");

        foreach (Asset_SO  asset in assetReferenceManager.AssetReferenceData.AllAssets)
        {
            asset.IsUnlocked = false;
        }
        JSON_Controller json = GetComponent<JSON_Controller>();
        json.CreateSaveAssetsJSON();
    }

    public void ResetAllCurrency()
    {
        Debug.Log("Reset Currency");

        CommonCurrency = 0;
        PremiumCurrency = 0;
        GachaCurrency = 0;
    }
    
    public void GiveTestCurrency()
    {
        Debug.Log("Give Test Currency");

        CommonCurrency = 1000;
        PremiumCurrency = 1000;
        GachaCurrency = 1000;
    }

    public void UnLockAllAssets()
    {
        Debug.Log("Unlock Assets");
        foreach (Asset_SO  asset in assetReferenceManager.AssetReferenceData.AllAssets)
        {
            asset.IsUnlocked = true;
            // JSON_Controller json = GetComponent<JSON_Controller>();
            // json.ChangeAssetValues(asset.ID, true);
        }

    }
    #endregion
}


[CustomEditor(typeof(SaveManager))]
public class SaveManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        SaveManager saveManager = target as SaveManager;
        
        if (GUILayout.Button("Reset Cat Data"))
        {
            saveManager.ResetCatData();
        }
        if (GUILayout.Button("Reset Assets"))
        {
            saveManager.ResetAllAssets();
        }  
        if (GUILayout.Button("Reset Currency"))
        {
            saveManager.ResetAllCurrency();
        }
        if (GUILayout.Button("Give Test Currency"))
        {
            saveManager.GiveTestCurrency();
        }
        if (GUILayout.Button("Give All Assets"))
        {
            saveManager.UnLockAllAssets();
        }

       
        
    }
}
