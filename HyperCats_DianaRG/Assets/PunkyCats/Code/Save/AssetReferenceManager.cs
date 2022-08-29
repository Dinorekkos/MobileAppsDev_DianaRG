using System.Collections;
using System.Collections.Generic;
using DinoFramework;
using UnityEngine;

public class AssetReferenceManager : MonoBehaviour
{
    private static AssetReferenceManager _instance;
    

    public const string REFERENCES_DATA_FILE_NAME = "AssetReferenceData";

   
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
