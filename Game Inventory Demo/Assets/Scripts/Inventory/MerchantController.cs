
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class MerchantController : MonoBehaviour
{
    [Header("Merchant Settings and References")] 
    [SerializeField] private GameObject itemOnSalePrefab;
    [SerializeField] private Transform sellListUI;


    private List<ItemData> _itemsOnSell = new List<ItemData>();
    private UniversalObjectPool _pool;

    private void Awake()
    {
        _pool = GetComponent<UniversalObjectPool>();
    }

    private void Start()
    {
        _pool.InitializePool(itemOnSalePrefab);
        Initialize();
    }

    private void Initialize()
    {
        var availableItemsList = DataBaseController.AvailableItems;
        _itemsOnSell = availableItemsList.OrderBy(item => item.price).ToList();

        PopulateSellList();
    }

    private void PopulateSellList()
    {
        foreach(var item in _itemsOnSell)
        {
            var newStoreItem = _pool.GetObject(itemOnSalePrefab);
            newStoreItem.transform.SetParent(sellListUI);
            var itemComponent = newStoreItem.GetComponent<StoreItem>();
            itemComponent.Initialize(item);
            itemComponent.SetSprite(DataBaseController.GetImage(item));

        }

    }


}
