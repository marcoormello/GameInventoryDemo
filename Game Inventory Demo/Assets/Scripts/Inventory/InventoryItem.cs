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

    private ItemData _currentItemData;
    
    
    public void Initialize(ItemData itemData)
    {
        _currentItemData = itemData;
        image.sprite = DataBaseController.GetImage(itemData);
    }
}
