using System;
using UnityEngine;


public class EquipmentUI : MonoBehaviour
{
    public static Action<Sprite> OnUpdateHead;
    public static Action<Sprite> OnUpdateBody;
    public static Action<Sprite> OnUpdateBack;
    public static Action<Sprite> OnUpdateFront;
    
    [Header("EquipmentUI References")]
    [SerializeField] private ContainerSlot headSlot;
    [SerializeField] private ContainerSlot bodySlot;
    [SerializeField] private ContainerSlot backSlot;
    [SerializeField] private ContainerSlot frontSlot;

    private void OnEnable()
    {
        headSlot.OnSlotOccupied += UpdateHeadSprite;
        bodySlot.OnSlotOccupied += UpdateBodySprite;
        backSlot.OnSlotOccupied += UpdateBackSprite;
        frontSlot.OnSlotOccupied += UpdateFrontSprite;

        MerchantUI.OnMerchantUIActive += AdjustPanelPosition;
        
        OpenEquipmentUI();
        
    }

    private void AdjustPanelPosition(bool state)
    {
        if (state)
        {
            LeanTween.moveLocalX(gameObject, -614f, 0.2f).setEase(LeanTweenType.easeInOutQuart);
        }
        else
        {
            LeanTween.moveLocalX(gameObject, -372.5f, 0.2f).setEase(LeanTweenType.easeInOutQuart);;
        }
    }

    private void OnDisable()
    {
        headSlot.OnSlotOccupied -= UpdateHeadSprite;
        bodySlot.OnSlotOccupied -= UpdateBodySprite;
        backSlot.OnSlotOccupied -= UpdateBackSprite;
        frontSlot.OnSlotOccupied -= UpdateFrontSprite;
        
        MerchantUI.OnMerchantUIActive -= AdjustPanelPosition;
    }

    private void UpdateFrontSprite(GameObject obj)
    {
        if (obj == null)
        {
            OnUpdateFront?.Invoke(null);
            return;
        }
        
        if (obj.TryGetComponent(out InventoryItem inventoryItem))
        {
            var itemData = inventoryItem.currentItemData;
            OnUpdateFront?.Invoke(DataBaseController.GetImage(itemData));
        }  
    }

    private void UpdateBackSprite(GameObject obj)
    {
        if (obj == null)
        {
            OnUpdateBack?.Invoke(null);
            return;
        }
        
        if (obj.TryGetComponent(out InventoryItem inventoryItem))
        {
            var itemData = inventoryItem.currentItemData;
            OnUpdateBack?.Invoke(DataBaseController.GetImage(itemData));
        }  
    }

    private void UpdateBodySprite(GameObject obj)
    {
        if (obj == null)
        {
            OnUpdateBody?.Invoke(null);
            return;
        }
        
        if (obj.TryGetComponent(out InventoryItem inventoryItem))
        {
            var itemData = inventoryItem.currentItemData;
            OnUpdateBody?.Invoke(DataBaseController.GetImage(itemData));
        }  
    }

    private void UpdateHeadSprite(GameObject obj)
    {
        if (obj == null)
        {
            OnUpdateHead?.Invoke(null);
            return;
        }
        
        if (obj.TryGetComponent(out InventoryItem inventoryItem))
        {
            var itemData = inventoryItem.currentItemData;
            OnUpdateHead?.Invoke(DataBaseController.GetImage(itemData));
        }  
    }

    private void OpenEquipmentUI()
    {
        transform.localScale = new Vector3(0, 0, 0);
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), 0.25f).setEase(LeanTweenType.easeSpring);
    }
    
    public void CloseEquipmentUI()
    {
        LeanTween.scale(gameObject, new Vector3(0, 0, 0), 0.5f).setOnComplete(Deactivate).setEase(LeanTweenType.easeSpring);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }


}
