using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    public Currency Gold;
    public Inventory inventory;

    public int healthPoints;


    protected virtual void Start()
    {
        Gold = new Currency("Gold");
        inventory = new Inventory();
        healthPoints = 100;
    }
    protected virtual void Update()
    {
        if (healthPoints == 0) { OnDeath(); }
    }

    protected virtual void OnDeath()
    {
        Debug.Log("Death for " + this.gameObject.name);
    }

    public virtual void DeductHealth(int damage)
    {
        healthPoints = healthPoints - damage;
    }

}
