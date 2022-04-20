using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{

    [SerializeField] public UI_Inventory uiInventory;
    [SerializeField] public UI_Stats uiStats;

    public int experience;


    protected override void Start()
    {
        base.Start();
        uiInventory.SetInventory(inventory);
    }

    protected override void Update()
    {
        uiStats.SetPlayer(this);
        base.Update();
    }

}
