using UnityEngine;
namespace DinoFramework
{
    [CreateAssetMenu(menuName = "DinoFramework/Asset", fileName = "AssetData")]
    public class Asset_SO : ScriptableObject
    {

        [SerializeField] private AssetType _assetType;
        [SerializeField] private string _id;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private bool isUnlocked;

       public bool IsUnlocked
       {
           get => isUnlocked;
       }

       public Sprite Sprite
       {
           get => _sprite;
       }

       public string ID
       {
           get => _id;
       }

       public AssetType AssetType
       {
           get => _assetType;
       }

       
    }
}