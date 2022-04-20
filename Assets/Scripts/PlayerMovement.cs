using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 movementInput;

    public float moveSpeed = 0.5f;

    private BoxCollider2D boxPlayer;

    public KeyboardInput keyboardInput;

    RaycastHit2D boxHit;

    public Animator animator;


    private void Start()
    {
        boxPlayer = GetComponent<BoxCollider2D>();
        keyboardInput = GetComponent<KeyboardInput>();
    }

    private void Update()
    {
        movementInput = keyboardInput.movementInput;

        animator.SetFloat("Horizontal", movementInput.x);
        animator.SetFloat("Speed", movementInput.magnitude);
        

    }

    private void FixedUpdate()
    {

        if (movementInput != Vector2.zero){
            boxHit = Physics2D.BoxCast(transform.position, boxPlayer.size, 0, new Vector2(0, movementInput.y), Mathf.Abs(movementInput.y * moveSpeed * Time.fixedDeltaTime), LayerMask.GetMask("Actor", "Blocking", "InteractableBlocking"));

            if (boxHit.collider == null)
            {
                transform.Translate(0, movementInput.y * moveSpeed * Time.deltaTime, 0);
            }

            boxHit = Physics2D.BoxCast(transform.position, boxPlayer.size, 0, new Vector2(movementInput.x, 0), Mathf.Abs(movementInput.x * moveSpeed * Time.fixedDeltaTime), LayerMask.GetMask("Actor", "Blocking", "InteractableBlocking"));

            //player movement
            if (boxHit.collider == null)
            {
                transform.Translate(movementInput.x * moveSpeed * Time.deltaTime, 0, 0);
            }

            if (movementInput.x > 0) { transform.localScale = Vector3.one; }
            if (movementInput.x < 0) { transform.localScale = new Vector3(-1, 1, 1); }

        }
    }
}
