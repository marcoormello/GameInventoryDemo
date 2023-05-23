using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContainerSlot : MonoBehaviour, IDropHandler
{
    public Action<GameObject> OnSlotOccupied;
    public ItemType itemType;


    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            if (itemType != ItemType.Default)
            {
                var draggedItemType = eventData.pointerDrag.GetComponent<InventoryItem>().itemType;
                if(itemType != draggedItemType) return;
            }
            
            var draggableItem = eventData.pointerDrag.GetComponent<DraggableItem>();
            draggableItem.slotParent = transform;
            OnSlotOccupied?.Invoke(draggableItem.gameObject);
        }
    }

    public void ItemRemoved()
    {
        OnSlotOccupied?.Invoke(null);
    }
}
