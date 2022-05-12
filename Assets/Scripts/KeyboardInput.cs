using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    //script for keyboard input handling
    public Vector2 movementInput { get; private set; }

    public bool hideInvButton;

    private void Start()
    {
        hideInvButton = false;
    }

    public void buttonHideInventory()
    {
        hideInvButton = true;
    }

    private void Update()
    {
        // movement input
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
        if(hideInvButton == true) { GetComponent<Player>().uiInventory.HideInventory(); hideInvButton = false; }

    }
}
