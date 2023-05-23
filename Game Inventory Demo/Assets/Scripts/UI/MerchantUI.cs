using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MerchantUI : MonoBehaviour
{
    public static Action<InventoryItem> OnItemSell;

    [Header("MerchantUI References")] 
    [SerializeField] private TextMeshProUGUI currentCoins;
    [SerializeField] private Button buyButton;
    [SerializeField] private Button sellButton;
    [SerializeField] private Transform buyMenu;
    [SerializeField] private Transform sellMenu;
    [SerializeField] private GameObject informationPanel;
    [SerializeField] private TextMeshProUGUI informationPrompt;
    [SerializeField] private CointainerSlot sellContainer;
    [SerializeField] private GameObject sellConfirmation;
    [SerializeField] private TextMeshProUGUI sellPrice;
    [SerializeField] private TextMeshProUGUI sellName;

    private InventoryItem _selectedItem;


    private void Awake()
    {
        sellContainer = GetComponentInChildren<CointainerSlot>();
    }

    private void OnEnable()
    {
        CurrencyController.OnCurrencyUpdate += UpdateCurrency;
        TransactionController.OnInsufficientFunds += InsufficientFunds;
        TransactionController.OnTransactionSuccessful += TransactionSuccessful;
        TransactionController.OnInventoryFull += InventoryFull;
        sellContainer.OnSlotOccupied += SellItemBehaviour;
        
        sellMenu.gameObject.SetActive(false);
    }
    

    private void OnDisable()
    {
        CurrencyController.OnCurrencyUpdate -= UpdateCurrency;
        TransactionController.OnInsufficientFunds -= InsufficientFunds;
        TransactionController.OnTransactionSuccessful -= TransactionSuccessful;
        TransactionController.OnInventoryFull -= InventoryFull;
        sellContainer.OnSlotOccupied -= SellItemBehaviour;
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
    
    public void SwitchState(bool state)
    {
        buyButton.gameObject.SetActive(state);
        buyMenu.gameObject.SetActive(!state);
        sellButton.gameObject.SetActive(!state);
        sellMenu.gameObject.SetActive(state);
    }
    
    private void SellItemBehaviour(GameObject item)
    {
        if (item.TryGetComponent(out InventoryItem inventoryItem))
        {
            sellConfirmation.SetActive(true);
            sellName.text = inventoryItem.currentItemData.itemName;
            sellPrice.text = inventoryItem.currentItemData.price.ToString(CultureInfo.InvariantCulture);
            _selectedItem = inventoryItem;
        }
        
    }

    private void CleanSellUI()
    {
        sellName.text = "";
        sellPrice.text = "";
        sellConfirmation.SetActive(false);
    }
    

    public void ConfirmedSell()
    {
        OnItemSell?.Invoke(_selectedItem);
        CleanSellUI();
    }
}
