using System;
using System.Collections;
using System.Collections.Generic;
using DinoFramework;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    public Action OnFinishedLoadingAssets;
    public AssetReferenceManager assetReferenceManager;

    [SerializeField] private Currency_SO commonSavedSO;
    [SerializeField] private Currency_SO premiumSavedSO;
    [SerializeField] private Currency_SO gachaSavedSO;

    public Action<int> OnCurrencyChanged;

    public int CommonCurrency
    {
        get { return commonSavedSO.SavedCurrency; }
        set { commonSavedSO.SavedCurrency = value; }
    }

    public int PremiumCurrency
    {
        get { return premiumSavedSO.SavedCurrency; }
        set { premiumSavedSO.SavedCurrency = value; }
    }

    public int GachaCurrency
    {
        get { return gachaSavedSO.SavedCurrency; }
        set { gachaSavedSO.SavedCurrency = value; }
    }
    

    private List<Asset_SO> loadAssets;
    private List<Asset_SO> unlockAssets;
    private List<Asset_SO> lockedAssets;
    
    


    public List<Asset_SO> UnlockedAssets
    {
        get => unlockAssets;
    }

    [HideInInspector]
    public Asset_SO emptyAsset;

    void Awake()
    {
        Instance = this;
        
    }

    private void Start()
    {
        LoadAssets();
    }


    void LoadAssets()
    {
        loadAssets = new List<Asset_SO>();
        unlockAssets = new List<Asset_SO>();
        lockedAssets = new List<Asset_SO>();
        loadAssets = assetReferenceManager.AssetReferenceData.AllAssets;

        foreach (Asset_SO  asset in loadAssets)
        {
            if (asset.IsUnlocked)
            {
                unlockAssets.Add(asset);
            }
            else
            {
                lockedAssets.Add(asset);
            }
        }

        emptyAsset = new Asset_SO();
        
        OnFinishedLoadingAssets?.Invoke();
    }


    public void AddCurrency(int cuantity, CurrencyType type)
    {
        switch (type)
        {
            case CurrencyType.Common:
                CommonCurrency += cuantity;
                break;
            case CurrencyType.Premium:
                PremiumCurrency += cuantity;
                break;
            case CurrencyType.Gacha:
                GachaCurrency += cuantity;
                break;
        }
        
        OnCurrencyChanged?.Invoke(0);
        // Debug.Log("Se guarda =  " + cuantity + " Currency : " + type);
    }

    public void BuyCurrency(CurrencyType myCurrencyType, CurrencyType desireCurrency, int substractCurrency, int addCurrency)
    {
        bool canBuyCurrency = false;
        switch (myCurrencyType)
        {
            case CurrencyType.Common: 
                if (CommonCurrency > 0) 
                {
                    canBuyCurrency = true; 
                    CommonCurrency -= substractCurrency; 
                } 
                break;
            case CurrencyType.Premium:
                if (PremiumCurrency > 0)
                {
                    canBuyCurrency = true;
                    PremiumCurrency -= substractCurrency;
                }
                break;
            case CurrencyType.Gacha:
                if (GachaCurrency > 0)
                {
                    canBuyCurrency = true;
                    GachaCurrency -= substractCurrency;
                }
                
                break;
        }

        if (canBuyCurrency)
        {
            Debug.Log("Se compran monedas");
            AddCurrency(addCurrency, desireCurrency);
        }
        else
        {
            Debug.LogError("No hay suficientes monedas para comprar");
        }
    }

    public void SpendCurrency(CurrencyType type, int amount)
    {
        switch (type)
        {
            case CurrencyType.Common:
                if (CommonCurrency > 0)
                {
                    CommonCurrency -= amount;
                    OnCurrencyChanged?.Invoke(0);

                }
                else
                {
                    Debug.LogError("No hay suficientes monedas para gastar");
                }
                break;
            case CurrencyType.Premium:
                if (PremiumCurrency > 0)
                {
                    PremiumCurrency -= amount;
                    OnCurrencyChanged?.Invoke(0);

                }
                else
                {
                    Debug.LogError("No hay suficientes monedas para gastar");
                }
                break;
            case CurrencyType.Gacha:
                if (GachaCurrency > 0)
                {
                    GachaCurrency -= amount;
                    OnCurrencyChanged?.Invoke(0);

                }
                else
                {
                    Debug.LogError("No hay suficientes monedas para gastar");
                }
                break;
        }
    }
    
}
