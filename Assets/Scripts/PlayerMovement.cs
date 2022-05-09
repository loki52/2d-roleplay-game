using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement 
{
    private Vector2 movementInput;

    private float horizontal;

    private void Update()
    {
        movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        horizontal = movementInput.x;

        if (movementInput.magnitude > 0.01)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        } 


        base.UpdateMove(movementInput);
    }

}
