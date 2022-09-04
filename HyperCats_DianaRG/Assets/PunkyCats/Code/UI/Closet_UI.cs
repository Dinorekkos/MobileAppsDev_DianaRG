using System;
using System.Collections;
using System.Collections.Generic;
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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ChangeFilter(int assetInt)
    {
        AssetType assetType = (AssetType) assetInt;
        OnChangedFilter?.Invoke(assetType);
    }
    
}
