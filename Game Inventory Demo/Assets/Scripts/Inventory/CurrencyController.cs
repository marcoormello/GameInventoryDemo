using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyController : MonoBehaviour
{
    public static Action<float> OnCurrencyUpdate;

    [Header("Currency Settings")] 
    [SerializeField] private float startingCurrency;
    
    private static float playerCurrency;

    public static float GetPlayerCurrency()
    {
        return playerCurrency;
    }

    private void Awake()
    {
        IncreaseCurrency(startingCurrency);
    }

    private void DecreaseCurrency(float amount)
    {
        playerCurrency -= amount;
        OnCurrencyUpdate?.Invoke(playerCurrency);
    }
    private void IncreaseCurrency(float amount)
    {
        playerCurrency += amount;
        OnCurrencyUpdate?.Invoke(playerCurrency);
    }

    public bool BuyTransaction(float cost)
    {
        if (cost < playerCurrency)
        {
            DecreaseCurrency(cost);
            return true;
        }
        
        return false;
    }
    
    public void SellTransaction(float cost)
    {
        IncreaseCurrency(cost);
    }
    
}
