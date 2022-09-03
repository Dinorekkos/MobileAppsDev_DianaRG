using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    public static UI_Controller Instance;
    [SerializeField] private GameObject[] InGameUIs;

    public Action<int> OnChangeUI;


    private void Awake()
    {
        Instance = this;

    }

    void Start()
    {
    }

    void Update()
    {
        
    }

    public void OpenWindowUI(int selectedUI)
    {
        for (int i = 0; i < InGameUIs.Length; i++)
        {
            InGameUIs[i].SetActive(false);
        }
        InGameUIs[selectedUI].SetActive(true);
        UpdateCurrenciesUIs();
    }
    
    public void UpdateCurrenciesUIs()
    {
        OnChangeUI?.Invoke(0);
    }
}
