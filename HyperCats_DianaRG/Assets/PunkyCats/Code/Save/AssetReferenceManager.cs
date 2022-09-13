using System.Collections;
using System.Collections.Generic;
using DinoFramework;
using UnityEngine;

public class AssetReferenceManager : MonoBehaviour
{
    public AssetReference_Data _assetReferenceData;

    public AssetReference_Data AssetReferenceData
    {
        get { return _assetReferenceData; }
        set
        {
            _assetReferenceData = value;
        }
    }
    
    
}
