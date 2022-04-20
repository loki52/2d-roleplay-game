using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    private Player playerComponent;

    [SerializeField] public UI_Chest uiChest;

    public Inventory inventory { get; private set; }

    private void Start()
    {
        inventory = new Inventory();
        uiChest.SetInventory(inventory);
    }

    public override void OnInteract(GameObject player)
    {
        uiChest.ShowInventory();
    }

    public override void StopInteract(GameObject player)
    {
        base.StopInteract(player);
        uiChest.HideInventory();
    }
}

