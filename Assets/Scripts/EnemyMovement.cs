using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Movement
{
    private Collider2D[] targetsInRadius;

    private float targetRadius;

    private Vector2 movementInput;

    private float attackDistance;

    private void Awake()
    {
        attackDistance = 0.3f;
        targetRadius = 0.8f;
    }
    private void Update()
    {
        targetsInRadius = Physics2D.OverlapCircleAll(transform.position, targetRadius, LayerMask.GetMask("Player"));
        for(int i = 0; i < targetsInRadius.Length; i++)
        {
            if (targetsInRadius[i] != null)
            {
                float distance = Vector2.Distance(targetsInRadius[i].transform.position, transform.position);
                if (distance < attackDistance)
                {
                    this.GetComponent<EnemyAttack>().Attack(targetsInRadius[i].gameObject);
                }
                movementInput = targetsInRadius[i].transform.position - transform.position;
                //float targetAngle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
                //transform.Rotate(targetAngle);
            }
        }
    }

    protected override void FixedUpdate()
    {
        base.UpdateMove(movementInput);
    }
}
