using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Sword,
        HealthPotion,
    }

    public string itemID;
    public string itemName;
    public Sprite itemIcon;
    public int itemAmount;

    public ItemType itemType;

    public Item()
    {

    }

    public Sprite GetIcon()
    {
        switch (itemType)
        {
            default:
            case ItemType.Sword: return ItemAssets.assetsInstance.swordSprite;
            case ItemType.HealthPotion: return ItemAssets.assetsInstance.redPotionSprite;
        }
    }
}
