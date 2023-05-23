
using UnityEngine;

public class MainUIController : MonoBehaviour
{

    [Header("MainUI References")] 
    [SerializeField] private InventoryUI inventory;
    [SerializeField] private EquipmentUI equipment;
    [SerializeField] private MerchantUI merchant;
    [SerializeField] private GameObject merchantCamera;

    public void OpenInventory()
    {
        inventory.gameObject.SetActive(true);
        equipment.gameObject.SetActive(true);
    }
    public void OpenAll()
    {
        merchantCamera.SetActive(true);
        
        OpenInventory();

        OpenMerchant();
    }
    public void CloseAll()
    {
        merchantCamera.SetActive(false);
        
        CloseInventory();

        CloseMerchant();
    }

    #region PRIVATE METHODS

    private void OpenMerchant()
    {
        merchant.gameObject.SetActive(true);
    }

    private void CloseInventory()
    {
        inventory.CloseInventoryUI();
        equipment.CloseEquipmentUI();
    }

    private void CloseMerchant()
    {
        merchant.CloseMerchantUI();
    }

    #endregion

}
