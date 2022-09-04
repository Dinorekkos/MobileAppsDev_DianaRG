using System;
using System.Collections;
using System.Collections.Generic;
using DinoFramework;
using UnityEngine;

public class ClosetController : MonoBehaviour
{
    [SerializeField] private List<AssetViwer> assetsViwers;
    void Start()
    {
        SaveManager.Instance.OnUnlockAsset += CreateItemsInventory;
    }

    private void OnEnable()
    { 
        SaveManager.Instance.OnUnlockAsset += CreateItemsInventory;
    }

    private void OnDisable()
    {
        SaveManager.Instance.OnUnlockAsset -= CreateItemsInventory;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateItemsInventory()
    {
        List<Asset_SO> unlockdeAssets = SaveManager.Instance.UnlockedAssets;
        for (int i = 0; i < unlockdeAssets.Count; i++)
        {
            
        }
        foreach (Asset_SO assetData in unlockdeAssets)
        {
            
        }
        foreach (AssetViwer viewer in assetsViwers)
        {
            viewer.CatUI.ResetAssets();
        }
    }
    
}
