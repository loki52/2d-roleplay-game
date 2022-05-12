using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Movement
{
    private Collider2D[] targetsInRadius;

    private float targetRadius;

    private Vector2 movementInput;

    public float attackDistance;
    public float timeStartChase { get; private set; }

    public float distanceTravelled { get; private set; }

    public GameObject targetChase { get; private set; }

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
                targetChase = targetsInRadius[i].gameObject;
            }
        }
        if(targetChase != null) { ChaseTarget(targetChase); }
        base.UpdateMove(movementInput);
    }

    private void ChaseTarget(GameObject target)
    {
        float distance = Vector2.Distance(target.transform.position, transform.position);
        if (distance < attackDistance)
        {
            this.GetComponent<EnemyAttack>().Attack(target.gameObject);
        }
        movementInput = target.transform.position - transform.position;
    }
}
