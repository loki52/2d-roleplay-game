using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollision : MonoBehaviour
{

    public ContactFilter2D contactFilter;
    private Collider2D[] collidersHit = new Collider2D[6];
    private BoxCollider2D bCollider;
    private Collider2D[] collidersReal = new Collider2D[6];


    protected virtual void Start()
    {
        bCollider = GetComponent<BoxCollider2D>();
    }
    
    protected virtual void Update()
    {
        collidersHit = new Collider2D[6];
        collidersReal = new Collider2D[6];
        int arrayIndex = 0;
        bCollider.OverlapCollider(contactFilter, collidersHit);
        foreach(Collider2D hit in collidersHit)
        {
            if (hit != null)
            {
                //will store all collisions in a list
                collidersReal[arrayIndex] = hit;
                arrayIndex += 1;
            }
        }
        if(collidersReal != null) { OnCollisions(collidersReal); }
    }

    protected virtual void OnCollisions(Collider2D[] collidersReal)
    {
        
    }
}
