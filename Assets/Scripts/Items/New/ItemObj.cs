using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObj : ScriptableObject
{
    public enum ItemType
    {
        Weapon,
        Potion,
    }

    public string itemID;
    public string itemName;
    public Sprite itemIcon;
    public ItemType itemType;
}
