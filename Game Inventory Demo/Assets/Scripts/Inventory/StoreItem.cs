
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreItem : MonoBehaviour
{
    [Header("Store Item Prefab Rererences")] 
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI price;
    [SerializeField] private Image icon;

    private const string AssetPath = "Assets/LocalDB/ItemSprites/";
    private ItemData _currentItemData;
        
    public void Initialize(ItemData itemData)
    {
        _currentItemData = itemData;
        
        itemName.text = itemData.itemName;
        price.text = itemData.price.ToString();
    }

    public void SetSprite(Sprite sprite)
    {
        if (sprite != null)
        {
            icon.sprite = sprite;
        }
        else
        {
            Debug.LogError("Failed to load sprite");
        }
    }
}
