
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [HideInInspector] public Transform slotParent;

    private Image _itemImage;

    private void Awake()
    {
        _itemImage = GetComponent<Image>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _itemImage.raycastTarget = false;
        slotParent = transform.parent;

        if (slotParent.TryGetComponent(out ContainerSlot containerSlot))
        {
            containerSlot.ItemRemoved();
        }
        
        transform.SetParent(transform.root);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _itemImage.raycastTarget = true;
        transform.SetParent(slotParent);
    }
}
