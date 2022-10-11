using System.Collections;
using System.Collections.Generic;
using DinoFramework;
using UnityEngine;
using UnityEngine.UI;

public class StoreSection : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private AssetType _sectionType;

    public AssetType SectionType
    {
        get => _sectionType;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
