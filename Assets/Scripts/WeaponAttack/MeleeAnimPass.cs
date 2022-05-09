using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class MeleeAnimPass : MonoBehaviour
{
    MeleeAimSwing melee;
    Animator animator;

    Weapon weaponScript;


    private void Start()
    {
        melee = GameObject.Find("MeleePoint1").GetComponent<MeleeAimSwing>();
        animator = GetComponent<Animator>();
        weaponScript = GetComponent<Weapon>();
    }

    public IEnumerator AttackAnim()
    {
        animator.SetBool("Swinging", true);
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("Swinging", false);
        weaponScript.ClearCollisions();
    }

}
