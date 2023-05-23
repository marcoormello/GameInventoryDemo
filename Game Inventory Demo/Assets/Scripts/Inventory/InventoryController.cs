using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public static Action<GameObject> OnAddItemToInventory;

    [Header("Inventory References")] 
    [SerializeField] private GameObject inventoryItemPrefab;
    
    private UniversalObjectPool _pool;

    private void Awake()
    {
        _pool = GetComponent<UniversalObjectPool>();
        _pool.InitializePool(inventoryItemPrefab);
    }

    public void SendItemToInventory(ItemData itemData)
    {
        var newItem = _pool.GetObject(inventoryItemPrefab);
        var itemComponent = newItem.GetComponent<InventoryItem>();
        itemComponent.Initialize(itemData);
        
        OnAddItemToInventory?.Invoke(newItem);
    }
}
