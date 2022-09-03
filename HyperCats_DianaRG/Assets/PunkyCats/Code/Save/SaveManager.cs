using System;
using System.Collections;
using System.Collections.Generic;
using DinoFramework;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    public Action OnFinishedLoadingAssets;
    public AssetReferenceManager assetReferenceManager;

    [SerializeField] private Currency_SO commonSavedSO;
    [SerializeField] private Currency_SO premiumSavedSO;
    [SerializeField] private Currency_SO gachaSavedSO;

    

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
    

    private List<Asset_SO> loadAssets;
    private List<Asset_SO> unlockAssets;
    private List<Asset_SO> lockedAssets;
    
    


    public List<Asset_SO> UnlockedAssets
    {
        get => unlockAssets;
    }

    [HideInInspector]
    public Asset_SO emptyAsset;

    private void OnEnable()
    {
        Instance = this;

    }

    void Awake()
    {
        // Instance = this;
        
    }

    private void Start()
    {
        LoadAssets();
    }


    void LoadAssets()
    {
        loadAssets = new List<Asset_SO>();
        unlockAssets = new List<Asset_SO>();
        lockedAssets = new List<Asset_SO>();
        loadAssets = assetReferenceManager.AssetReferenceData.AllAssets;

        foreach (Asset_SO  asset in loadAssets)
        {
            if (asset.IsUnlocked)
            {
                unlockAssets.Add(asset);
            }
            else
            {
                lockedAssets.Add(asset);
            }
        }

        emptyAsset = new Asset_SO();
        
        OnFinishedLoadingAssets?.Invoke();
    }


    
}
