using System.Collections;
using System.Collections.Generic;
using DinoFramework;
using UnityEngine;
using UnityEngine.UI;

public class AssetViwer : MonoBehaviour
{
    public Cat_UI myCatUI;
    public AssetType type;
    public Asset_SO myAsset_Data;
    
    
    public void LoadAsset(Asset_SO assetSo)
    {
        myAsset_Data = assetSo;
        myCatUI.isAssetViwer = true;
        
        if(myAsset_Data != null)
        {
            type = myAsset_Data.AssetType;
            myCatUI.SetAssetViwer(type, myAsset_Data.Sprite);
        }
    }

    public void SelectAsset()
    {
        if (myAsset_Data != null)
        {
            switch (myAsset_Data.AssetType)
            {
                case AssetType.Skin:
                    SaveManager.Instance.SavedCatData.catSkin_Data = myAsset_Data;
                    break;
                case AssetType.Eyes: 
                    SaveManager.Instance.SavedCatData.catEyes_Data = myAsset_Data;
                    break;
                
                case AssetType.Hair:
                    SaveManager.Instance.SavedCatData.catHair_Data = myAsset_Data;
                    break;
                
                case AssetType.Head:
                    SaveManager.Instance.SavedCatData.catHead_Data = myAsset_Data;
                    break;
                
                case AssetType.Chest:
                    SaveManager.Instance.SavedCatData.catChest_Data = myAsset_Data;
                    break;
                
                case AssetType.Pants:
                    SaveManager.Instance.SavedCatData.catPants_Data = myAsset_Data;
                    break;
                
                case AssetType.Tail:
                    SaveManager.Instance.SavedCatData.catTail_Data = myAsset_Data;
                    break;
                
                case AssetType.Shoes:
                    SaveManager.Instance.SavedCatData.catShoes_Data = myAsset_Data;
                    break;

            }
            
            ClosetController.Instance.CatUI.UpdateCatSprites();
        }
    }
    
    
}
