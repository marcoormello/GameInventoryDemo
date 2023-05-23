using System;
using System.Collections;
using System.Globalization;
using UnityEngine;

public class TransactionController : MonoBehaviour
{
    public static Action OnTransactionSuccessful;
    public static Action OnInsufficientFunds;
    public static Action OnInventoryFull;
    
    private CurrencyController _currencyController;
    private InventoryController _inventoryController;



    private void OnEnable()
    {
        StoreItem.OnBuyRequest += BuyRequest;
        MerchantUI.OnItemSell += SellRequest;
    }


    private void OnDisable()
    {
        StoreItem.OnBuyRequest -= BuyRequest;
        MerchantUI.OnItemSell -= SellRequest;
    }

    private void Awake()
    {
        _currencyController = GetComponent<CurrencyController>();
        _inventoryController = GetComponent<InventoryController>();
    }

    public void BuyRequest(ItemData itemData)
    {
        var inventoryFull = InventoryUI.InventoryFull;
        if (inventoryFull)
        {
            OnInventoryFull?.Invoke();
            return;
        }
        
        if (!_currencyController.BuyTransaction(itemData.price))
        {
            OnInsufficientFunds?.Invoke();
            return;
        }
        
        OnTransactionSuccessful?.Invoke();
        _inventoryController.SendItemToInventory(itemData);
    }
    
    private void SellRequest(InventoryItem inventoryItem)
    {
        _currencyController.SellTransaction(inventoryItem.currentItemData.price);
        _inventoryController.ReturnToPool(inventoryItem.gameObject);
        
    }

}
