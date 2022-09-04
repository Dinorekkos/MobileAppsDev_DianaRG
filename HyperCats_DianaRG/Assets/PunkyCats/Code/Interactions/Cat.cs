using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DinoFramework;
using Lean.Common;
using Lean.Touch;
using Unity.VisualScripting;

public class Cat : MonoBehaviour
{
    public static Cat Instance;
    [Header("Data")]
    public Cat_Data myCatData;
    
    [Header("Renderers")]
    [SerializeField] private SpriteRenderer _catSkin_Renderer;
    [SerializeField] private SpriteRenderer _catEyes_Renderer;
    [SerializeField] private SpriteRenderer _catPants_Renderer;
    [SerializeField] private SpriteRenderer _catChest_Renderer;
    [SerializeField] private SpriteRenderer _catHair_Renderer;
    [SerializeField] private SpriteRenderer _catHead_Renderer;
    [SerializeField] private SpriteRenderer _catTail_Renderer;
    [SerializeField] private SpriteRenderer _catShoes_Renderer;

    [Header("Interactables")] 
    [SerializeField] private GameObject handGO;
    [SerializeField] private GameObject foodGO;

    private float timerActions = 3f;
    public Asset_SO[] myAssetsSO;
    public SpriteRenderer[] myRenderers;

    private Vector2 _originPosHand;
    private Vector2 _originPosFood;
    
    public bool isTimerActive;
    public bool isTimerPaused;
    public bool isTimerActionsFinished;
    private float timerInteractions;
    private float interpolationPeriod = 1f;

    private float catNeeds;

    public float MyCatNeeds
    {
        get { return catNeeds; }
        set { catNeeds = value; }
    }
    
    [SerializeField] private CatStates _catStates;

    public Action<float> OnNeedsAction;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SaveManager.Instance.OnFinishedLoadingAssets += InitializeCatData;
        GameController.Instance.OnCatBarNeedsFill += ResetCatNeeds;

    }

    private void Update()
    {
        if (_catStates != CatStates.Idle)
        {
            if (!isTimerActionsFinished)
            {
                CountTimer();
            } 
        }
    }

    private void OnEnable()
    {
        SaveManager.Instance.OnFinishedLoadingAssets += InitializeCatData;
        GameController.Instance.OnCatBarNeedsFill += ResetCatNeeds;

    }

    private void OnDisable()
    {
        SaveManager.Instance.OnFinishedLoadingAssets -= InitializeCatData;
        GameController.Instance.OnCatBarNeedsFill -= ResetCatNeeds;


    }

    void InitializeCatData()
    {
        _originPosFood = foodGO.transform.position;
        _originPosHand = handGO.transform.position;
        
        Gameplay_UI.Instance.OnSendCatState += HandleCatStates;

        ResetAssets();
        UpdateCatSprites();
        ResetGOInteractions();
       
    }

    void ResetAssets()
    {
        for (int i = 0; i < myRenderers.Length; i++)
        {
            myRenderers[i].sprite = null;
        }

    }
    public void UpdateCatSprites()
    {
        myAssetsSO = new[]
        {
            myCatData.catChest_Data, myCatData.catEyes_Data, myCatData.catSkin_Data, myCatData.catShoes_Data,
            myCatData.catTail_Data, myCatData.catHair_Data, myCatData.catHead_Data, myCatData.catPants_Data
        };
        if (myAssetsSO != null)
            foreach (Asset_SO asset in myAssetsSO)
            {
                if (asset != null)
                {
                    switch (asset.AssetType)
                    {
                        case AssetType.Head:
                            _catHead_Renderer.sprite = myCatData.catHead_Data.Sprite;
                            break;
                        case AssetType.Hair:
                            _catHair_Renderer.sprite = myCatData.catHair_Data.Sprite;
                            break;
                        case AssetType.Eyes:
                            _catEyes_Renderer.sprite = myCatData.catEyes_Data.Sprite;
                            break;
                        case AssetType.Chest:
                            _catChest_Renderer.sprite = myCatData.catChest_Data.Sprite;
                            break;
                        case AssetType.Tail:
                            _catTail_Renderer.sprite = myCatData.catTail_Data.Sprite;
                            break;
                        case AssetType.Pants:
                            _catPants_Renderer.sprite = myCatData.catPants_Data.Sprite;
                            break;
                        case AssetType.Shoes:
                            _catShoes_Renderer.sprite = myCatData.catShoes_Data.Sprite;
                            break;
                        case AssetType.Skin:
                            _catSkin_Renderer.sprite = myCatData.catSkin_Data.Sprite;
                            break;
                    }
                }
            }

    }



    public void HandleCatStates(CatStates states)
    {
        _catStates = states;
        ResetGOInteractions();
        switch (_catStates)
        {
            case CatStates.Idle :
                
                break;
            case CatStates.Petting:
                handGO.SetActive(true);
                
                break;
            case CatStates.Feeding:
                foodGO.SetActive(true);
                break;
            
        }
    }

    private void ResetGOInteractions()
    {
        handGO.transform.position = _originPosHand;
        foodGO.transform.position = _originPosFood;
        
        handGO.SetActive(false);
        foodGO.SetActive(false);
        
    }

    public void HandleInteractions(LeanFinger finger)
    {
        if (_catStates != CatStates.Idle)
        {
            if (handGO.activeSelf || foodGO.activeSelf)
            {
                if(catNeeds >= 6) 
                    return;

                if (isTimerActive && isTimerPaused)
                    PauseTimerActions(false);
                
                
                if (!isTimerActive) 
                    StartTimerActions();
            }
        }
       

        // switch (_catStates)
        // {
            // case CatStates.Feeding:
        
                // break;
            
            // case CatStates.Petting:
                
    }

    public void SetPause(LeanFinger leanFinger)
    {
        // Debug.Log("<color=#76FE18>pause timer</color>");
        PauseTimerActions(true);
    }
    void StartTimerActions()
    {
        isTimerActionsFinished = false;
        isTimerActive = true;
        timerActions = 3f;
    }

    void PauseTimerActions(bool pause)
    {
        if (isTimerActive && !isTimerActionsFinished)
        {
            isTimerPaused = pause;
        }
    }
    
    void ResetTimerActions()
    {
        isTimerActive = false;
        isTimerPaused = false;
        timerActions = 0;
    }

    void CountTimer()
    {
        
        if (timerActions <= 0)
        {
            if(!isTimerActive) return;
            isTimerActionsFinished = true;
            ResetTimerActions();
            ResetGOInteractions();
        }

        if (isTimerActive)
        {
            if (!isTimerPaused)
            {
                timerActions -= Time.deltaTime;
                catNeeds += 1 * Time.deltaTime;
                SendingCatNeeds(catNeeds);
            }
        }
    }

    void SendingCatNeeds(float needs)
    {
        OnNeedsAction?.Invoke(needs);
    }

    void ResetCatNeeds(int amount)
    {
        amount = 0;
        catNeeds = amount;
    }
}
