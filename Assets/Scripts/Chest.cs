using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    private Player playerComponent;

    public override void OnInteract(GameObject player)
    {
        playerComponent = player.GetComponent<Player>();
        playerComponent.Gold.AddCurrency(15);
        StopInteract(player);
    }
}
