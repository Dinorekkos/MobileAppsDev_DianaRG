using System;
using System.Collections;
using System.Collections.Generic;
using DinoFramework;
using UnityEngine;

public class ClosetController : MonoBehaviour
{
    [SerializeField] private AssetViwer itemPrefab;
    [SerializeField] private RectTransform contentPanel;
    
    [SerializeField] private List<AssetViwer> itemsInv;

    [SerializeField] private CurrencyType filterAssets;
    void Start()
    {
        // SaveManager.Instance.OnUnlockAsset += InitializeInventoryUI;
    }

    private void OnEnable()
    { 
        // SaveManager.Instance.OnUnlockAsset += InitializeInventoryUI;
    }

    private void OnDisable()
    {
        // SaveManager.Instance.OnUnlockAsset -= InitializeInventoryUI;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeInventoryUI()
    {
        List<Asset_SO> unlockdeAssets = SaveManager.Instance.UnlockedAssets;
     
        for (int i = 0; i < unlockdeAssets.Count; i++)
        {
            AssetViwer assetViwer = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            assetViwer.transform.SetParent(contentPanel);
            itemsInv.Add(assetViwer);

            Asset_SO assetSo = unlockdeAssets[i]; 
            Debug.Log(assetSo.ID); 
            assetViwer.myAsset_Data = assetSo;
            assetViwer.CatUI.SetAssetViwer(assetSo.AssetType, assetSo.Sprite);
        }
        
        
    }
    
}
