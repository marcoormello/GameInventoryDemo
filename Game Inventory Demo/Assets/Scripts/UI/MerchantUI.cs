using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MerchantUI : MonoBehaviour
{
    [Header("MerchantUI References")] 
    [SerializeField] private TextMeshProUGUI currentCoins;
    [SerializeField] private Button buyButton;
    [SerializeField] private Button sellButton;
    [SerializeField] private Transform buyMenu;
    [SerializeField] private Transform sellMenu;
    [SerializeField] private GameObject informationPanel;
    [SerializeField] private TextMeshProUGUI informationPrompt;

    private void OnEnable()
    {
        CurrencyController.OnCurrencyUpdate += UpdateCurrency;
        TransactionController.OnInsufficientFunds += InsufficientFunds;
        TransactionController.OnTransactionSuccessful += TransactionSuccessful;
        TransactionController.OnInventoryFull += InventoryFull;
    }

    private void OnDisable()
    {
        CurrencyController.OnCurrencyUpdate -= UpdateCurrency;
        TransactionController.OnInsufficientFunds -= InsufficientFunds;
        TransactionController.OnTransactionSuccessful -= TransactionSuccessful;
        TransactionController.OnInventoryFull -= InventoryFull;
    }

    private void TransactionSuccessful()
    {
        informationPanel.SetActive(true);
        informationPrompt.text = "Successful purchase!";
    }
    private void InventoryFull()
    {
        informationPanel.SetActive(true);
        informationPrompt.text = "Inventory Full!";
    }
    private void InsufficientFunds()
    {
        informationPanel.SetActive(true);
        informationPrompt.text = "Not Enough Coins!";
    }



    private void UpdateCurrency(float currentAmount)
    {
        currentCoins.text = currentAmount.ToString(CultureInfo.InvariantCulture);
    }
}
