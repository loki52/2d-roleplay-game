using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollision : MonoBehaviour
{

    public ContactFilter2D contactFilter;
    protected Collider2D[] collidersHit = new Collider2D[6];
    protected BoxCollider2D bCollider;
    protected Collider2D[] collidersReal = new Collider2D[6];


    protected virtual void Start()
    {
        bCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {
        Collider2D[] collidersHit = new Collider2D[6];
        bCollider.OverlapCollider(contactFilter, collidersHit);
        foreach (Collider2D hit in collidersHit)
        {
            if (hit == null) { continue; }
            if (hit != null)
            {
                OnCollide(hit);
            }
        }
    }

    protected virtual void OnCollide(Collider2D collide)
    {

    }
}
