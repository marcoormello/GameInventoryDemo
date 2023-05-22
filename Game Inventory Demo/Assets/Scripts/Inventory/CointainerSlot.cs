using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CointainerSlot : MonoBehaviour, IDropHandler
{
    
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            var draggableItem = eventData.pointerDrag.GetComponent<DraggableItem>();
            draggableItem.slotParent = transform;
        }
    }
}
