using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DinoFramework;
public class Cat : MonoBehaviour
{
    [Header("Data")]
    public Cat_Data myCatData;
    
    [Header("Renderers")]
    [SerializeField] private SpriteRenderer _catSkin_Renderer;
    [SerializeField] private SpriteRenderer _catEyes_Renderer;
    [SerializeField] private SpriteRenderer _catPants_Renderer;
    [SerializeField] private SpriteRenderer _catChest_Renderer;
    [SerializeField] private SpriteRenderer _catHair_Renderer;
    [SerializeField] private SpriteRenderer _catHead_Renderer;
    [SerializeField] private SpriteRenderer _catTail_Renderer;
    [SerializeField] private SpriteRenderer _catShoes_Renderer;

    private Asset_SO[] myAssetsSO;
    private SpriteRenderer[] myRenderers;
    void Start()
    {
        SaveManager.Instance.OnFinishedLoadingAssets += InitializeCatData;
    }

    void InitializeCatData()
    {

        myAssetsSO = new[]
        {
            myCatData.catChest_Data, myCatData.catEyes_Data, myCatData.catSkin_Data, myCatData.catShoes_Data,
            myCatData.catTail_Data, myCatData.catHair_Data, myCatData.catHead_Data, myCatData.catPants_Data
        };
        myRenderers = new[]
        {
            _catSkin_Renderer, _catEyes_Renderer, _catPants_Renderer, _catChest_Renderer, _catHair_Renderer,
            _catHead_Renderer, _catTail_Renderer, _catShoes_Renderer
        };

        for (int i = 0; i < myRenderers.Length; i++)
        {
            myRenderers[i].sprite = null;
        }
        
        UpdateCatSprites();

       
    }

    void UpdateCatSprites()
    {
        if (myAssetsSO != null)
            foreach (Asset_SO asset in myAssetsSO)
            {
                if (asset != null)
                {
                    switch (asset.AssetType)
                    {
                        case AssetType.Head:
                            _catHead_Renderer.sprite = myCatData.catHead_Data.Sprite;
                            break;
                        case AssetType.Hair:
                            _catHair_Renderer.sprite = myCatData.catHair_Data.Sprite;
                            break;
                        case AssetType.Eyes:
                            _catEyes_Renderer.sprite = myCatData.catEyes_Data.Sprite;
                            break;
                        case AssetType.Chest:
                            _catChest_Renderer.sprite = myCatData.catChest_Data.Sprite;
                            break;
                        case AssetType.Tail:
                            _catTail_Renderer.sprite = myCatData.catTail_Data.Sprite;
                            break;
                        case AssetType.Pants:
                            _catPants_Renderer.sprite = myCatData.catPants_Data.Sprite;
                            break;
                        case AssetType.Shoes:
                            _catShoes_Renderer.sprite = myCatData.catShoes_Data.Sprite;
                            break;
                        case AssetType.Skin:
                            _catSkin_Renderer.sprite = myCatData.catSkin_Data.Sprite;
                            break;
                    }
                }
            }

    }
}
