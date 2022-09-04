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

    // Update is called once per frame
    void Update()
    {
        
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
        Asset_SO selectedAsset = null;
        
        int random = Random.Range(0, lockedAssets.Count);
        
        Debug.Log(random);
        
        selectedAsset = lockedAssets[random];
        selectedAsset.IsUnlocked = true;
        
        SaveManager.Instance.UpdateLists();

        return selectedAsset;
    }
    
    
    
    
}
