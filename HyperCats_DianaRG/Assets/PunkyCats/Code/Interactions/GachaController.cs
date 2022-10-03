using System;
using System.Collections;
using System.Collections.Generic;
using DinoFramework;
using UnityEngine;
using Random = UnityEngine.Random;

public class GachaController : MonoBehaviour
{
    public static GachaController Instance;
    private List<Asset_SO> lockedAssets;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SaveManager.Instance.OnFinishedLoadingAssets += Initialize;
    }
    

    private void OnEnable()
    {
        SaveManager.Instance.OnFinishedLoadingAssets += Initialize;

    }

    private void OnDisable()
    {
        SaveManager.Instance.OnFinishedLoadingAssets -= Initialize;

    }

    void Initialize()
    {
        lockedAssets = SaveManager.Instance.LockedAssets;

    }

    public Asset_SO ShowAssetUI()
    {
        Asset_SO myAsset = SelectRandomAsset();
        Debug.Log("Selected asset ID :  " + myAsset.ID);

        return myAsset;
    }

    private Asset_SO SelectRandomAsset()
    {
        lockedAssets = SaveManager.Instance.LockedAssets;
        int random = Random.Range(0, lockedAssets.Count);
        
        Asset_SO  selectedAsset = lockedAssets[random];
        if (selectedAsset.ID == "eyes.default" || selectedAsset.ID == "skin.default" )
        {
            selectedAsset = SelectRandomAsset();
        }
        selectedAsset.IsUnlocked = true;
        
        SaveManager.Instance.SaveAssetChanges(selectedAsset.ID, true);
        SaveManager.Instance.UpdateLists();

        return selectedAsset;
    }
    
    
    
    
}
