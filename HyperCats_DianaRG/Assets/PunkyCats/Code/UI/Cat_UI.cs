using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DinoFramework;

public class Cat_UI : MonoBehaviour
{
    
    [Header("Data")]
    public Cat_Data myCatData;
    
    [Header("Renderers")]
    [SerializeField] private Image _catSkin_Image;
    [SerializeField] private Image _catEyes_Image;
    [SerializeField] private Image _catPants_Image;
    [SerializeField] private Image _catChest_Image;
    [SerializeField] private Image _catHair_Image;
    [SerializeField] private Image _catHead_Image;
    [SerializeField] private Image _catTail_Image;
    [SerializeField] private Image _catShoes_Image;

    // private Action OnWeareAsset;

    public bool isAssetViwer;

    public Asset_SO[] myAssetsSO;
    public Image[] myRenderersImages;
    
    
    
    void Start()
    {
        if (!isAssetViwer)
        {
            ResetAssets();
            UpdateCatSprites();
        }
        
    }

  

   public void UpdateCatSprites()
    {
        myAssetsSO = new[]
        {
            myCatData.catChest_Data, myCatData.catEyes_Data, myCatData.catSkin_Data, myCatData.catShoes_Data,
            myCatData.catTail_Data, myCatData.catHair_Data, myCatData.catHead_Data, myCatData.catPants_Data
        };
        if (myAssetsSO != null)
        {
            foreach (Asset_SO asset in myAssetsSO)
            {
                if (asset != null)
                {
                    switch (asset.AssetType)
                    {
                        case AssetType.Head:
                            _catHead_Image.sprite = myCatData.catHead_Data.Sprite;
                            _catHead_Image.color = Color.white;
                            break;
                        case AssetType.Hair:
                            _catHair_Image.sprite = myCatData.catHair_Data.Sprite;
                            _catHair_Image.color = Color.white;

                            break;
                        case AssetType.Eyes:
                            _catEyes_Image.sprite = myCatData.catEyes_Data.Sprite;
                            _catEyes_Image.color = Color.white;

                            break;
                        case AssetType.Chest:
                             _catChest_Image.sprite = myCatData.catChest_Data.Sprite;
                            _catChest_Image.color = Color.white;

                            break;
                        case AssetType.Tail:
                             _catTail_Image.sprite = myCatData.catTail_Data.Sprite;
                            _catTail_Image.color = Color.white;

                            break;
                        case AssetType.Pants:
                             _catPants_Image.sprite = myCatData.catPants_Data.Sprite;
                            _catPants_Image.color = Color.white;

                            break;
                        case AssetType.Shoes:
                             _catShoes_Image.sprite = myCatData.catShoes_Data.Sprite;
                            _catShoes_Image.color = Color.white;

                            break;
                        case AssetType.Skin:
                            _catSkin_Image.sprite = myCatData.catSkin_Data.Sprite;
                            _catSkin_Image.color = Color.white;

                            break;
                    }
                }
            }
        }
    }

   public void ResetAssets()
    {
        for (int i = 0; i < myRenderersImages.Length; i++)
        {
            myRenderersImages[i].color = new Color(0,0,0,0);
        }
    }

    public void SetAssetViwer(AssetType assetType, Sprite assetSprite)
    {
        ResetAssets();
        switch (assetType)
        {
            case AssetType.Head:
                if (isAssetViwer) _catHead_Image.sprite = assetSprite;
                _catHead_Image.color = Color.white;
                break;
            case AssetType.Hair:
                if (isAssetViwer) _catHair_Image.sprite = assetSprite;
                _catHair_Image.color = Color.white;

                break;
            case AssetType.Eyes:
                if (isAssetViwer) _catEyes_Image.sprite = assetSprite;
                _catEyes_Image.color = Color.white;

                break;
            case AssetType.Chest:
                if (isAssetViwer) _catChest_Image.sprite = assetSprite;
                _catChest_Image.color = Color.white;

                break;
            case AssetType.Tail:
                if (isAssetViwer) _catTail_Image.sprite = assetSprite;
                _catTail_Image.color = Color.white;

                break;
            case AssetType.Pants:
                if (isAssetViwer) _catPants_Image.sprite = assetSprite;
                _catPants_Image.color = Color.white;

                break;
            case AssetType.Shoes:
                if (isAssetViwer) _catShoes_Image.sprite = assetSprite;
                _catShoes_Image.color = Color.white;

                break;
            case AssetType.Skin:
                if (isAssetViwer) _catSkin_Image.sprite = assetSprite;
                _catSkin_Image.color = Color.white;

                break;
        }
        
    }
    
    
    
}
