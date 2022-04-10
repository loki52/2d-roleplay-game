using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory
{
    public int baseInventorySize = 5;
    public int InventorySize { get; private set; }

    public List<Item> inventoryList { get; private set; }
    
    public Inventory()
    {
        inventoryList = new List<Item>();
        InventorySize = baseInventorySize;
        AddItem(new Item { itemType = Item.ItemType.HealthPotion, itemAmount = 1, itemName = "Health Potion" });
        AddItem(new Item { itemType = Item.ItemType.Sword, itemAmount = 1, itemName = "Dagger" });
    }

    public int AddItem(Item item)
    {
        if ((inventoryList.Count() + 1) <= InventorySize) {
            inventoryList.Add(item);
            return 0;
        }
        else { return 1; }
    }
}
