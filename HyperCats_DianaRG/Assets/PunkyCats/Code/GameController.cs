using System;
using System.Collections;
using System.Collections.Generic;
using DinoFramework;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public int currencyForBar = 5;
    private float needsCatBar = 6;

    public Action<int> OnCatBarNeedsFill;


    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (SaveManager.Instance.Initialized) Initialize();
        
        // else
        // {
        // SaveManager.Instance.OnFinishedLoadingAssets += Initialize;
        // }
    }

    // private void OnEnable()
    // {
        // Cat.Instance.OnNeedsAction += HandleCatNeeds;
        // OnCatBarNeedsFill += SaveBarCurrency;
    // }
    
    void Initialize()
    {
        Debug.Log("<color=#FC7B47>Initilized= </color>" + name);

        Cat.Instance.OnNeedsAction += HandleCatNeeds;
        OnCatBarNeedsFill += SaveBarCurrency;
    }
        
    
    private void OnDisable()
    {
        Cat.Instance.OnNeedsAction -= HandleCatNeeds;
        OnCatBarNeedsFill -= SaveBarCurrency;
    }

    
    void HandleCatNeeds(float catNeeds)
    {

        if (catNeeds >= needsCatBar)
        {
            OnCatBarNeedsFill?.Invoke(currencyForBar);
        }
    }

    private void SaveBarCurrency(int cuantity)
    { 
        Debug.Log("<color=#FC7B47>Add currency= </color>" + name);

        CurrencyManager.Instance.AddCurrency(cuantity, CurrencyType.Common);
        
    }
    




}
