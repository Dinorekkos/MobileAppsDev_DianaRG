using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DinoFramework;

namespace DinoFramework
{
    public class CurrencyManager : MonoBehaviour
    {
        public static CurrencyManager Instance;

        // private int commonCurrency;
        // private int premiumCurrency;
        // private int gachaCurrency;

        public Action<int> OnCurrencyChanged;
        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {
        }
        
        public void AddCurrency(int cuantity, CurrencyType type)
        {
            switch (type)
            {
                case CurrencyType.Common:
                   SaveManager.Instance.CommonCurrency += cuantity;
                    break;
                case CurrencyType.Premium:
                    SaveManager.Instance.PremiumCurrency += cuantity;
                    break;
                case CurrencyType.Gacha:
                    SaveManager.Instance.GachaCurrency += cuantity;
                    break;
            }

       

            OnCurrencyChanged?.Invoke(0);
            // Debug.Log("Se guarda =  " + cuantity + " Currency : " + type);
        }

        public void BuyCurrency(CurrencyType myCurrencyType, CurrencyType desireCurrency, int substractCurrency, int addCurrency)
        {
            // bool canBuyCurrency = false;
            // switch (myCurrencyType)
            // {
            //     case CurrencyType.Common:
            //         if (CommonCurrency > 0)
            //         {
            //             canBuyCurrency = true;
            //             CommonCurrency -= substractCurrency;
            //         }
            //
            //         break;
            //     case CurrencyType.Premium:
            //         if (PremiumCurrency > 0)
            //         {
            //             canBuyCurrency = true;
            //             PremiumCurrency -= substractCurrency;
            //         }
            //
            //         break;
            //     case CurrencyType.Gacha:
            //         if (GachaCurrency > 0)
            //         {
            //             canBuyCurrency = true;
            //             GachaCurrency -= substractCurrency;
            //         }
            //
            //         break;
            // }


            if (CanSubstractCurrency(0, myCurrencyType, substractCurrency))
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
            if (CanSubstractCurrency(0,type, amount))
            {
                OnCurrencyChanged?.Invoke(0);
            }
            else
            {
                Debug.LogError("No hay suficientes monedas para gastar");
            }
            
            // switch (type)
            // {
            //     case CurrencyType.Common:
            //         if (CommonCurrency > 0)
            //         {
            //             CommonCurrency -= amount;
            //             OnCurrencyChanged?.Invoke(0);
            //
            //         }
            //         else
            //         {
            //             Debug.LogError("No hay suficientes monedas para gastar");
            //         }
            //
            //         break;
            //     case CurrencyType.Premium:
            //         if (PremiumCurrency > 0)
            //         {
            //             PremiumCurrency -= amount;
            //             OnCurrencyChanged?.Invoke(0);
            //
            //         }
            //         else
            //         {
            //             Debug.LogError("No hay suficientes monedas para gastar");
            //         }
            //
            //         break;
            //     case CurrencyType.Gacha:
            //         if (GachaCurrency > 0)
            //         {
            //             GachaCurrency -= amount;
            //             OnCurrencyChanged?.Invoke(0);
            //
            //         }
            //         else
            //         {
            //             Debug.LogError("No hay suficientes monedas para gastar");
            //         }
            
        }



        private bool CanSubstractCurrency(int minium, CurrencyType currencyType, int substractCurrency)
        {
            bool canSubstractCurrency = false;

            int commonCurrency = SaveManager.Instance.CommonCurrency;
            int premiumCurrency = SaveManager.Instance.PremiumCurrency;
            int gachaCurrency = SaveManager.Instance.GachaCurrency;
            
            switch (currencyType)
            {
                case CurrencyType.Common:
                    if (commonCurrency > minium )
                    {
                        canSubstractCurrency = true;
                        SaveManager.Instance.CommonCurrency -= substractCurrency;
                    }

                    break;
                case CurrencyType.Premium:
                    if (premiumCurrency > 0)
                    {
                        canSubstractCurrency = true;
                        SaveManager.Instance.PremiumCurrency -= substractCurrency;
                    }

                    break;
                case CurrencyType.Gacha:
                    if (gachaCurrency > 0)
                    {
                        canSubstractCurrency = true;
                        SaveManager.Instance.GachaCurrency -= substractCurrency;
                    }

                    break;
            }

            return canSubstractCurrency;
        }
        
    }
}
