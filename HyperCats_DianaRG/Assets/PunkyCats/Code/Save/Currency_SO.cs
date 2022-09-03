using UnityEngine;

namespace DinoFramework
{
    [CreateAssetMenu(menuName = "DinoFramework/CurrencyData", fileName = "CurrencyData")]

    public class Currency_SO : ScriptableObject
    {
        [SerializeField] private CurrencyType _currencyType;
        [SerializeField] private int saveCurrency;

        public int SavedCurrency
        {
            get { return saveCurrency; }
            set { saveCurrency = value; }
        }

        public CurrencyType MyCurrencyType
        {
            get { return _currencyType; }
        }
    }
}

