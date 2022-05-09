using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Weapon : BoxCollision
{

    //damage
    public int damage;

    //in-game sprite
    private SpriteRenderer weaponGameSprite;

    //weapon box colldier
    private BoxCollider2D boxCollider;

    //public Animator weaponAnimator;

    private float cooldown = 0.25f;
    private float lastAttack;

    private RaycastHit2D[] rayHit = new RaycastHit2D[5];
    public ContactFilter2D mouseFilter;



    private List<Collider2D> attacked = new List<Collider2D>();

    private PlayerAimWeapon aimWeapon;

    protected override void Start()
    {
        base.Start();
        damage = 25;
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected override void OnCollide(Collider2D collide)
    {
        int fail = 0;
        int i = 0;
        for (i = 0; i < attacked.Count; i++)
        {
            if (attacked[i] == collide) { fail = 1; }
        }
        if (collide != null && collide.tag != "Player" && collide.tag == "Hostile" && fail == 0)
        {
            collide.gameObject.GetComponent<Entity>().DeductHealth(damage, this.gameObject);
            attacked.Add(collide);
        }
    }
}
