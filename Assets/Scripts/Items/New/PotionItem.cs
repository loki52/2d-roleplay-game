using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Potion", menuName = "InventoryInstance/Items/Potion")]
public class PotionItem : ItemObj
{
    public int restoreHP;

    private void Awake()
    {
        itemType = ItemType.Potion;
    }
}
