using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "InventoryInstance/Items/Weapon")]
public class WeaponItem : ItemObj
{
    public int attackDamage;
    public GameObject prefab;

    private void Awake()
    {
        itemType = ItemType.Weapon;
    }
}
