
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
        
        OpenInventoryUI();

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
    
    public void OpenInventoryUI()
    {
        transform.localScale = new Vector3(0, 0, 0);
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), 0.25f).setEase(LeanTweenType.easeSpring);
    }
    public void CloseInventoryUI()
    {
        LeanTween.scale(gameObject, new Vector3(0, 0, 0), 0.5f).setOnComplete(Deactivate);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

}
