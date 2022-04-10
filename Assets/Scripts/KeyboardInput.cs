using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    //script for keyboard input handling
    public Vector2 movementInput { get; private set; }

    private void Update()
    {
        // movement input
        movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Input.GetButtonDown("OpenBackpack") && !(GetComponent<Player>().uiInventory.gameObject.activeSelf))
        {
            //if button is held down and there is no inventory
            //present, show the inventory
            GetComponent<Player>().uiInventory.ShowInventory();
        }
        else if (Input.GetButtonDown("OpenBackpack") && GetComponent<Player>().uiInventory.gameObject.activeSelf)
        {
            //if the button is held down and there is an
            //inventory present, hide it
            GetComponent<Player>().uiInventory.HideInventory();
        }

    }
}
