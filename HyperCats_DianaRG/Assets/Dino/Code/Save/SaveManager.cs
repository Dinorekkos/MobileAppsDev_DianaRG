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
    
    private List<Asset_SO> loadAssets;
    private List<Asset_SO> unlockAssets;
    private List<Asset_SO> lockedAssets;

    public List<Asset_SO> UnlockedAssets
    {
        get => unlockAssets;
    }


    void Awake()
    {
        LoadAssets();
    }

    private void Start()
    {
        Instance = this;
        OnFinishedLoadingAssets += LoadCatClothe;
    }


    void LoadAssets()
    {
        loadAssets = new List<Asset_SO>();
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
        OnFinishedLoadingAssets?.Invoke();
    }

    void LoadCatClothe ()
    {
        
    }
    
}
