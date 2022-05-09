using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    public Currency Gold;
    public InventoryObj inventory;

    public int healthPoints;

    public bool Death;

    private Vector2 pushLocation;

    protected GameObject damageOrigin;


    protected virtual void Start()
    {
        healthPoints = 100;
        Gold = new Currency("Gold");
    }
    protected virtual void Update()
    {
        if (healthPoints <= 0) { Death = true; OnDeath(); }
    }

    protected virtual void OnDeath()
    {
        Destroy(this.gameObject);
    }

    public virtual void DeductHealth(int damage, GameObject origin)
    {
        if (Death != true)
        {
            if (healthPoints - damage < 0) { healthPoints = 0; }
            else
            {
                healthPoints -= damage;
            }
        }
        damageOrigin = origin;
    }
}
