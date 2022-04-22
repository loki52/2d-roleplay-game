using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : BoxCollision
{

    //damage
    public int damage;

    //in-game sprite
    private SpriteRenderer weaponGameSprite;

    //weapon box colldier
    private BoxCollider2D boxCollider;

    public Animator weaponAnimator;

    private float cooldown = 0.5f;
    private float lastAttack;


    private List<Collider2D> attacked = new List<Collider2D>();

    protected override void Start()
    {
        base.Start();
        damage = 25;
        weaponGameSprite = GetComponent<SpriteRenderer>();

    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time - lastAttack > cooldown)
            {
                lastAttack = Time.time;
                attacked.Clear();
                weaponAnimator.SetTrigger("Attack");
            }
        }
    }

    protected override void OnCollide(Collider2D collide)
    {
        int fail = 0;
        int i = 0;
        for (i = 0; i < attacked.Count; i++)
        {
            if (attacked[i] == collide) { fail = 1; }
        }
        //Debug.Log("collide = " + collide.name + "collidetag = " + collide.tag + " fail = " + fail);
        if (collide != null && collide.tag != "Player" && collide.tag == "Hostile" && fail == 0)
        {
            //Debug.Log("attacking");
            collide.gameObject.GetComponent<Entity>().DeductHealth(damage);
            attacked.Add(collide);
        }
        //else { Debug.Log("failed"); }
    }
}
