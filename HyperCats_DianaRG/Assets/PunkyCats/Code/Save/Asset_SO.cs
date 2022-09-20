using UnityEngine;
namespace DinoFramework
{
    [CreateAssetMenu(menuName = "DinoFramework/Asset", fileName = "AssetData")]
    [System.Serializable]
    public class Asset_SO : ScriptableObject
    {

        [SerializeField] private AssetType _assetType;
        [SerializeField] private string _id;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private bool isUnlocked;

       public bool IsUnlocked
       {
           get => isUnlocked;
           set => isUnlocked = value;
       }

       public Sprite Sprite
       {
           get => _sprite;
       }

       public string ID
       {
           get => _id;
           set => _id = value;
       }

       public AssetType AssetType
       {
           get => _assetType;
       }

       
    }
}