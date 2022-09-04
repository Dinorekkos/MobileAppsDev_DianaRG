using System;
using System.Collections.Generic;
using DinoFramework;
using UnityEngine;
using UnityEditor;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    public Action OnFinishedLoadingAssets;
    public AssetReferenceManager assetReferenceManager;

    [SerializeField] private Currency_SO commonSavedSO;
    [SerializeField] private Currency_SO premiumSavedSO;
    [SerializeField] private Currency_SO gachaSavedSO;

    public Action OnUnlockAsset;
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
        _loadAssets = assetReferenceManager.AssetReferenceData.AllAssets;

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
        
        foreach (Asset_SO  asset in _loadAssets)
        {
            if (asset.IsUnlocked)
            {
                _unlockAssets.Add(asset);
                // Debug.Log(asset.ID);
            }
            else
            {
                _lockedAssets.Add(asset);
                // Debug.Log(asset.ID);
            }
        }
        Debug.Log("Unlocked Count = " + _unlockAssets.Count);
        Debug.Log("Locked Count = " + _lockedAssets.Count);
        
        OnUnlockAsset?.Invoke();
    }

    

    #region Editor
    
    public void ResetAllAssets()
    {
        Debug.Log("Reset Assets");

        foreach (Asset_SO  asset in assetReferenceManager.AssetReferenceData.AllAssets)
        {
            asset.IsUnlocked = false;
        }
        
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
