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
        Cat.Instance.OnNeedsAction += HandleCatNeeds;
        OnCatBarNeedsFill += SaveBarCurrency;
    }

    private void OnEnable()
    {
        Cat.Instance.OnNeedsAction += HandleCatNeeds;
        OnCatBarNeedsFill += SaveBarCurrency;
    }

    private void OnDisable()
    {
        Cat.Instance.OnNeedsAction -= HandleCatNeeds;
        OnCatBarNeedsFill -= SaveBarCurrency;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        SaveManager.Instance.AddCurrency(cuantity, CurrencyType.Common);
    }
    




}
