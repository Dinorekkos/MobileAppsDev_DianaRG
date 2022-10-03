using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PunkyCats.Code
{
    [System.Serializable]
    public class Save_CurrencySO
    {
        public string _id;
        public int _currencyAmount;

        public Save_CurrencySO(string id, int currencyAmount)
        {
            _id = id;
            _currencyAmount = currencyAmount;
        }
    }
}