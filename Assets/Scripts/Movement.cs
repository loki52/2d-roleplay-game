using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    protected float moveSpeed = 1.15f;

    protected BoxCollider2D boxEntity;

    RaycastHit2D boxHit;

    public Animator animator;


    protected virtual void Start()
    {
        boxEntity = GetComponent<BoxCollider2D>();
    }

    protected virtual void UpdateMove(Vector2 movementInput)
    {
        if (movementInput != Vector2.zero)
        {
            boxHit = Physics2D.BoxCast(transform.position, boxEntity.size, 0, new Vector2(movementInput.x, 0), Mathf.Abs(movementInput.x * moveSpeed * Time.fixedDeltaTime), LayerMask.GetMask("Actor", "Blocking", "InteractableBlocking"));

            if (boxHit.collider == null)
            {
                transform.Translate(movementInput.x * moveSpeed * Time.deltaTime, 0, 0);
            }

            boxHit = Physics2D.BoxCast(transform.position, boxEntity.size, 0, new Vector2(0, movementInput.y), Mathf.Abs(movementInput.y * moveSpeed * Time.fixedDeltaTime), LayerMask.GetMask("Actor", "Blocking", "InteractableBlocking"));

            if (boxHit.collider == null)
            {
                transform.Translate(0, movementInput.y * moveSpeed * Time.deltaTime, 0);
            }

            if (movementInput.x > 0) { transform.localScale = Vector3.one; }
            if (movementInput.x < 0) { transform.localScale = new Vector3(-1, 1, 1); }

        }
    }



}
