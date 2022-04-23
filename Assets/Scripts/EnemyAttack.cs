using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private float cooldown = 1f;
    private float lastAttack;

    public int damage;

    public void Attack(GameObject target)
    {
        if (Time.time - lastAttack > cooldown)
        {
            lastAttack = Time.time;
            target.GetComponent<Entity>().DeductHealth(damage, this.gameObject);
        }
    }


}
