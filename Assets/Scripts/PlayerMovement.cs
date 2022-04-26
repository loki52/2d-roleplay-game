using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement 
{
    private Vector2 movementInput;
    private void Update()
    {
        movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        animator.SetFloat("Horizontal", movementInput.x);
        animator.SetFloat("Speed", movementInput.magnitude);

        base.UpdateMove(movementInput);
    }
}
