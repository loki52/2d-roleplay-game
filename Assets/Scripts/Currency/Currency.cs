using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency
{
    public string CurrencyName { get; private set; }
    public int CurrencyAmount { get; private set; }
    public Currency(string currencyName)
    {
        CurrencyName = currencyName;
        CurrencyAmount = 0;
    }

    public void AddCurrency(int value)
    {
        if (value >= 1)
        {
            CurrencyAmount += value;
        }
    }

    public void DeductCurrency(int value)
    {
        if (value < 0) { value = -value; }
        CurrencyAmount -= value;
        if (CurrencyAmount < 0) { CurrencyAmount = 0; }
    }
}
