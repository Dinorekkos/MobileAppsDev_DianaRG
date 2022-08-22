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
        
        
        
        
        
        [SerializeField] private List<Clothe> allAssetsList;
        
        public List<Clothe> AllAssets
        {
            get => allAssetsList;
        }

        private List<Clothe> _blockAssetsList;
        private List<Clothe> _unblockAssetsList;

    }
}