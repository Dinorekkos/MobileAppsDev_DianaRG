using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace DinoFramework
{
    [CreateAssetMenu(menuName = "DinoFramework/AssetsContainer", fileName = "AssetReferenceData")]
    public class AssetReference_Data : ScriptableObject
    {
        private static AssetReference_Data instance;

        public static AssetReference_Data Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = Resources.Load<AssetReference_Data>("AssetReferenceData");
                    
                    if (instance == null)
                        Debug.LogError ($"AssetReferencesData doesn't exist in Resources");
                }

                return instance;
            }
        }
        
        
        
        [SerializeField] private List<Asset_SO> allAssetsList;
        
        public List<Asset_SO> AllAssets
        {
            get => allAssetsList;
        }
        
        // private List<Asset_SO> _blockAssetsList;
        // private List<Asset_SO> _unblockAssetsList;

    }
}