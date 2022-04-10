using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public UI_Inventory uiInventory;

    public Currency Gold;
    public Inventory inventory;

    private void Start()
    {
        Gold = new Currency("Gold");
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
    }
    private void Update()
    {

    }
}
