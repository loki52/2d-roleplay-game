using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{

    [SerializeField] public UI_Inventory uiInventory;
    [SerializeField] public UI_Stats uiStats;

    public int experience;

    public ItemObj item;

    public ItemObj item2;


    protected override void Start()
    {
        base.Start();
        experience = 0;
        inventory.AddItem(item, 1);
        inventory.AddItem(item2, 50);

        uiInventory.SetInventory(inventory);
    }

    protected override void Update()
    {
        uiStats.SetPlayer(this);
        base.Update();
    }

    public void AddExperience(int amount)
    {
        if (amount > 0) { experience += amount; }
    }
}
