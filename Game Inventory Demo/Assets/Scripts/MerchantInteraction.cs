using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MerchantInteraction : MonoBehaviour
{
    [Header("MainUI References")] 
    [SerializeField] private GameObject canvasWorldSpace;
    void OnTriggerEnter2D (Collider2D other)
    {
        canvasWorldSpace.SetActive(true);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        canvasWorldSpace.SetActive(false);
    }
}
