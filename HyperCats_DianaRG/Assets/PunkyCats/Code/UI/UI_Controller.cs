using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    public static UI_Controller Instance;
    [SerializeField] private GameObject[] InGameUIs;
    [SerializeField] private int currentUI;
    [SerializeField] private int gameplayUI;

    public Action<int> OnChangeUI;


    private void Awake()
    {
        Instance = this;

    }
    

    public void OpenWindowUI(int selectedUI, bool closeOtherUIs = true)
    {
        for (int i = 0; i < InGameUIs.Length; i++)
        {
            InGameUIs[i].SetActive(!closeOtherUIs);
        }
        InGameUIs[selectedUI].SetActive(true);
        currentUI = selectedUI;
        UpdateCurrenciesUIs();
    }

    public void UIGoBack()
    {
        if (currentUI>0)
        {
            InGameUIs[currentUI].SetActive(false);
            InGameUIs[gameplayUI].SetActive(true);
            currentUI = -1;
        }
        
    }
    
    public void UpdateCurrenciesUIs()
    {
        OnChangeUI?.Invoke(0);
    }
}
