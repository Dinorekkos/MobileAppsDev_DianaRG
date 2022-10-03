using System;
using System.Collections;
using System.Collections.Generic;
using DinoFramework;
using UnityEngine;

public class ClosetController : MonoBehaviour
{

    public static ClosetController Instance;
    public Cat_UI CatUI;
    [SerializeField] private AssetViwer itemPrefab;
    [SerializeField] private RectTransform contentPanel;
    [SerializeField] private AssetType defaultFilter = AssetType.Skin;
    [SerializeField] List<AssetViwer> itemsDisplayed;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Closet_UI.Instance.OnChangedFilter += InitializeInventoryUI;
        InitializeInventoryUI(defaultFilter);
    }

    private void OnEnable()
    { 
        Closet_UI.Instance.OnChangedFilter += InitializeInventoryUI;
    }

    private void OnDisable()
    {
        Closet_UI.Instance.OnChangedFilter -= InitializeInventoryUI;

    }

    public void UpdateInventory()
    {
        InitializeInventoryUI(defaultFilter);
    }

    public void InitializeInventoryUI(AssetType filter)
    {
        List<Asset_SO> unlockdeAssets = SaveManager.Instance.UnlockedAssets;
        List<Asset_SO> filteredAssets = new List<Asset_SO>();
        

        if(itemsDisplayed.Count > 0)
        {
            foreach (AssetViwer item in itemsDisplayed)
            {
                Destroy(item.gameObject);
            }
            itemsDisplayed.Clear();
        }

        foreach (Asset_SO asset in unlockdeAssets)
        {
            if (asset.AssetType == filter)
            {
                filteredAssets.Add(asset);
            }
        }
        
        for (int i = 0; i < filteredAssets.Count; i++)
        {
            AssetViwer assetViwer = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            assetViwer.transform.SetParent(contentPanel);
            assetViwer.transform.localScale = Vector3.one;

            itemsDisplayed.Add(assetViwer);

            Asset_SO assetSo = filteredAssets[i];
            assetViwer.myAsset_Data = assetSo;
            assetViwer.myCatUI.SetAssetViwer(assetSo.AssetType, assetSo.Sprite);
        }
        
    }

    
    
}
