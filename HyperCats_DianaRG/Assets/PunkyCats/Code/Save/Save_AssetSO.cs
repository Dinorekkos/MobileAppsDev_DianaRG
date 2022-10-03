using DinoFramework;
using UnityEngine;

namespace PunkyCats.Code
{
    [System.Serializable]
    public class Save_AssetSO
    {
     
        public string _id;
        public bool _isUnlocked;

        public Save_AssetSO(string id,  bool isUnlocked)
        {
            _id = id;
            _isUnlocked = isUnlocked;
        }

    }
}