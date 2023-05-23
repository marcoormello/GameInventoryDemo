using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class DataBaseController : MonoBehaviour
{
    public string filePath = "Assets/LocalDB/availableItems.json";
    private const string ItemSpriteAtlas = "miniature-army1024x768";

    public static List<ItemData> AvailableItems;
    private static Sprite[] itemSprites;

    private void Awake()
    {
        itemSprites = Resources.LoadAll<Sprite>(ItemSpriteAtlas);
        LoadItemData();
    }

    private void LoadItemData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
        
            ItemDataWrapper wrapper = JsonUtility.FromJson<ItemDataWrapper>(json);
            AvailableItems = wrapper.items;
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
        }
    }
    
    public static Sprite GetImage(ItemData item)
    {
        return item == null ? null : itemSprites.SingleOrDefault(s => s.name == item.spritePath);
    }
}


public enum ItemType
{
    Default,
    Torso,
    Weapon,
    Head
}

[System.Serializable]
public class ItemData
{
    public string itemName;
    public float price;
    public string spritePath;
    public string itemType;
}

[System.Serializable]
public class ItemDataWrapper
{
    public List<ItemData> items;
}
