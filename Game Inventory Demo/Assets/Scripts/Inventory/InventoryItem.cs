using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    [Header("Inventory Item References")] 
    [SerializeField] private Image image;

    public ItemData currentItemData;
    public ItemType itemType;
    
    
    public void Initialize(ItemData itemData)
    {
        currentItemData = itemData;
        image.sprite = DataBaseController.GetImage(itemData);

        itemType = currentItemData.itemType switch
        {
            "Torso" => ItemType.Torso,
            "Weapon" => ItemType.Weapon,
            "Head" => ItemType.Head,
            _ => itemType
        };
    }
}
