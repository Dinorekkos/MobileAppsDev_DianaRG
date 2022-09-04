using System.Collections;
using System.Collections.Generic;
using DinoFramework;
using UnityEngine;
using UnityEngine.UI;

public class AssetViwer : MonoBehaviour
{
    public Cat_UI CatUI;
    public AssetType type;
    public Asset_SO myAsset_Data;
    
    public void LoadAsset(Asset_SO assetSo)
    {
        myAsset_Data = assetSo;
        CatUI.isAssetViwer = true;
        
        if(myAsset_Data != null)
        {
            type = myAsset_Data.AssetType;
            CatUI.SetAssetViwer(type, myAsset_Data.Sprite);
        }
    }
    
    
}
