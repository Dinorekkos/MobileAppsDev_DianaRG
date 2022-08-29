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

    private Asset_SO[] myAssetsSO;
    private Image[] myRenderersImages;
    void Start()
    {
        myAssetsSO = new[]
        {
            myCatData.catChest_Data, myCatData.catEyes_Data, myCatData.catSkin_Data, myCatData.catShoes_Data,
            myCatData.catTail_Data, myCatData.catHair_Data, myCatData.catHead_Data, myCatData.catPants_Data
        };
        myRenderersImages = new[]
        {
            _catSkin_Image, _catEyes_Image, _catPants_Image, _catChest_Image, _catHair_Image,
            _catHead_Image, _catTail_Image, _catShoes_Image
        };
        for (int i = 0; i < myRenderersImages.Length; i++)
        {
            myRenderersImages[i].color = new Color(0,0,0,0);
        }
        
        UpdateCatSprites();
    }

  

    void UpdateCatSprites()
    {
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
}
