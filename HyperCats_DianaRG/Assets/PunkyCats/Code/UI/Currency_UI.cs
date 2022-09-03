using System;
using System.Collections;
using System.Collections.Generic;
using DinoFramework;
using UnityEngine;
using UnityEngine.UI;

public class Currency_UI : MonoBehaviour
{
    [SerializeField] private Text currencyText;
    [SerializeField] private CurrencyType currencyType;
    void Start()
    {
        SaveManager.Instance.OnFinishedLoadingAssets += Initialze;
        GameController.Instance.OnCatBarNeedsFill += UpdateCurrencyUI;
    }

    private void OnEnable()
    {
        // SaveManager.Instance.OnFinishedLoadingAssets += Initialze;
    }

    private void OnDisable()
    {
        // SaveManager.Instance.OnFinishedLoadingAssets -= Initialze;
    }

    
    void Initialze()
    {
       UpdateCurrencyUI(0);
    }


    void UpdateCurrencyUI(int currency)
    {
        switch (currencyType)
        {
            case CurrencyType.Common:
                currencyText.text = SaveManager.Instance.CommonCurrency.ToString();
                break;
            case CurrencyType.Premium:
                currencyText.text = SaveManager.Instance.PremiumCurrency.ToString();
                break;
            
            case CurrencyType.Gacha:
                currencyText.text = SaveManager.Instance.GachaCurrency.ToString();
                break;
            
        }
    }
}
