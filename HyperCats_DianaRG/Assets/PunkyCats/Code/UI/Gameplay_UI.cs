using System;
using System.Collections;
using System.Collections.Generic;
using DinoFramework;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay_UI : MonoBehaviour
{
    public static Gameplay_UI Instance;
    [SerializeField] private GameObject _interactionsGO;
    [SerializeField] private Slider slider;
    
    private float interactPoints = 0;

    public Action<CatStates> OnSendCatState;

    
    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Initialize();
    }

    private void OnEnable()
    {
        // SaveManager.Instance.OnFinishedLoadingAssets += Initialize;

    }

    private void OnDisable()
    {
        // SaveManager.Instance.OnFinishedLoadingAssets -= Initialize;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Initialize()
    {

        interactPoints = Cat.Instance.MyCatNeeds;
        _interactionsGO.SetActive(false);

    }

    public void LoadUIButton(int UI)
    {
        UI_Controller.Instance.OpenWindowUI(UI);
    }

    public void InteractionsPanel(bool active)
    {
        if (_interactionsGO.activeSelf) active = !active;
        
        _interactionsGO.SetActive(active);
    }

    void UpdateSliderInteractions()
    {
        interactPoints++;
        slider.value = interactPoints;
    }

    public void ActivateCatInteraction(int catInt)
    {
        CatStates catState = (CatStates)catInt;
        OnSendCatState?.Invoke(catState);
    }
    
    
}
