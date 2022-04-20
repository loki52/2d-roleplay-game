using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : BoxCollision
{
    //attak delay
    public float attackDelay = 0.25f;

    //damage
    public int damage = 5;

    //in-game sprite
    private SpriteRenderer weaponGameSprite;

    //weapon box colldier
    private BoxCollider2D boxCollider;

    public Animator weaponAnimator;

    protected override void Start()
    {
        base.Start();
        weaponGameSprite = GetComponent<SpriteRenderer>();
    }

    protected override void Update()
    {
        if (Input.GetButtonDown("Fire1") && weaponAnimator.GetBool("Attack") == false)
        {
            weaponAnimator.SetTrigger("Attack"); 
        }
    }

    protected override void OnCollisions(Collider2D[] collidersReal)
    {
        foreach (Collider2D hit in collidersReal)
        {
            if(hit != null && hit.tag != "Player") {
                hit.gameObject.GetComponent<Entity>().DeductHealth(damage);
                
                }
        }
    }

}
