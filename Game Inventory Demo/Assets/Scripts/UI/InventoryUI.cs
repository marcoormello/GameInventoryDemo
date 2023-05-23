using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public static bool InventoryFull => AreAllSlotsOccupied();

    [Header("InventoryUI References")] 
    
    
    private static List<ContainerSlot> slots;
    
    private void OnEnable()
    {
        InventoryController.OnAddItemToInventory += AddItem;
    }
    private void OnDisable()
    {
        InventoryController.OnAddItemToInventory -= AddItem;
    }

    private void Awake()
    {
        slots = GetComponentsInChildren<ContainerSlot>().ToList();
    }

    private void AddItem(GameObject newItem)
    {
        foreach (var slot in slots)
        {
            var item = slot.GetComponentInChildren<InventoryItem>();
            if (item == null)
            {
                newItem.transform.SetParent(slot.transform);
                return;
            }
        }
    }
    
    private static bool AreAllSlotsOccupied()
    {
        foreach (var slot in slots)
        {
            var item = slot.GetComponentInChildren<InventoryItem>();
            if (item == null)
            {
                // At least one slot is not occupied
                return false;
            }
        }

        // All slots are occupied
        return true;
    }


}
