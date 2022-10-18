using System.Collections;
using System.Collections.Generic;
using DinoFramework;
using UnityEngine;
using UnityEngine.UI;

public class StoreCatSection : MonoBehaviour
{
    // [SerializeField] private StoreData _storeData;
    [SerializeField] private Image icon;
    [SerializeField] private AssetType _sectionType;

    public AssetType SectionType
    {
        get => _sectionType;
    }
    void Start()
    {
        //commit para 0.2
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
