using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public int experienceGive;

    protected override void OnDeath()
    {
        if (damageOrigin.transform.parent.gameObject.GetComponent<Player>() != null)
        {
            damageOrigin.transform.parent.gameObject.GetComponent<Player>().AddExperience(experienceGive);
        }
        base.OnDeath();
    }
}
