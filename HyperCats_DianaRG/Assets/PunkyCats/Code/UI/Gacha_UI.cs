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

    private Action OnGachaSpin;
    void Start()
    {
        PopUpItem.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BuyGachaPoints()
    {
        // SaveManager.Instance.BuyCurrency(currency.MyCurrencyType, CurrencyType.Gacha, gachaCost, gachaAmount);
        
        CurrencyManager.Instance.BuyCurrency(currency.MyCurrencyType, CurrencyType.Gacha, gachaCost, gachaAmount);
        
        currency.UpdateCurrencyUI(0);
    }

    public void SpinGacha()
    {
        // SaveManager.Instance.SpendCurrency(CurrencyType.Gacha, gachaAmount);
        CurrencyManager.Instance.SpendCurrency(CurrencyType.Gacha, gachaAmount);
        OnGachaSpin?.Invoke();
        
    }
}
