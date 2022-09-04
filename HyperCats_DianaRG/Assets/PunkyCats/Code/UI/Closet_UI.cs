using System;
using DinoFramework;
using UnityEngine;

public class Closet_UI : MonoBehaviour
{
    public static Closet_UI Instance;
    public Action<AssetType> OnChangedFilter;

    private void Awake()
    {
        Instance = this;
    }
    
    
    public void ChangeFilter(int assetInt)
    {
        AssetType assetType = (AssetType) assetInt;
        OnChangedFilter?.Invoke(assetType);
    }

    public void UpdateCatScene()
    {
        Cat.Instance.UpdateCatSprites();
    }
}
