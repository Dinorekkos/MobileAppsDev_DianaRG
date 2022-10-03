using System;
using System.Collections;
using System.Collections.Generic;
using DinoFramework;
using UnityEngine;
using UnityEngine.UI;

public class Gacha_UI : MonoBehaviour
{

    [Header("Gacha")] public int gachaCost;
    public int gachaAmount = 3;
    public Currency_UI currency;
    public GameObject PopUpItem;
    public AssetViwer assetViwer;

    void Start()
    {
        PopUpItem.SetActive(false);
    }

    public void BuyGachaPoints()
    {
        CurrencyManager.Instance.BuyCurrency(currency.MyCurrencyType, CurrencyType.Gacha, gachaCost, gachaAmount);
        currency.UpdateCurrencyUI(0);
    }

    public void SpinGacha()
    {
        if (SaveManager.Instance.LockedAssets.Count>=1)
        {
            if (CurrencyManager.Instance.SpendCurrency(CurrencyType.Gacha, gachaAmount))
            {
                PopUpItem.SetActive(true);
                assetViwer.LoadAsset(GachaController.Instance.ShowAssetUI());
            
            }  
        }
        
    }

    public void ClosePopUpItem()
    {
        PopUpItem.SetActive(false);
    }
    
    
}
