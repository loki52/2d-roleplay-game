using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    private Player playerComponent;

    [SerializeField] public UI_Container uiChest;

    public ItemObj item;

    public InventoryObj inventory;

    public override void OnInteract(GameObject player)
    {
        uiChest.SetInventory(inventory, "Chest");
        uiChest.ShowInventory();
        player.GetComponent<Player>().uiInventory.ShowInventory();
    }

    public override void StopInteract(GameObject player)
    {
        base.StopInteract(player);
        uiChest.HideInventory();
    }
}

