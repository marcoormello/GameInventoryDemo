using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    [Header("Sprite References")] 
    [SerializeField] private SpriteRenderer headSlot;
    [SerializeField] private SpriteRenderer bodySlot;
    [SerializeField] private SpriteRenderer backSlot;
    [SerializeField] private SpriteRenderer frontSlot;
    [Header("Default Clothes")] 
    [SerializeField] private Sprite headDefault;
    [SerializeField] private Sprite bodyDefault;
    [SerializeField] private Sprite backDefault;
    [SerializeField] private Sprite frontDefault;
    
    private void OnEnable()
    { 
        EquipmentUI.OnUpdateHead += SetHead;
       EquipmentUI.OnUpdateBody += SetBody;
       EquipmentUI.OnUpdateBack += SetBack;
       EquipmentUI.OnUpdateFront += SetFront;
       
    }
    private void OnDisable()
    {
        EquipmentUI.OnUpdateHead -= SetHead;
        EquipmentUI.OnUpdateBody -= SetBody;
        EquipmentUI.OnUpdateBack -= SetBack;
        EquipmentUI.OnUpdateFront -= SetFront;
    }

    private void SetFront(Sprite obj)
    {
        frontSlot.sprite = obj == null ? frontDefault : obj;
    }

    private void SetBack(Sprite obj)
    {
        backSlot.sprite = obj == null ? backDefault : obj;
    }

    private void SetBody(Sprite obj)
    {
        bodySlot.sprite = obj == null ? bodyDefault : obj;
    }

    private void SetHead(Sprite obj)
    {
        headSlot.sprite = obj == null ? headDefault : obj;
    }


}
