using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
    private Transform aimTransform;
    private int done;

    private int phase;

    private int angleOffset;

    private Quaternion _currentRotation;
    private Quaternion _targetRotation;
    private float rotatespeed = 0.025f;

    private float timeCount = 0.0f;

    private float lastAttackRot;

    private float timebeforeRot= 0.5f;

    private float angle;

    private PlayerMovement playerMove;

    private bool invertVec;
     
    private void Awake()
    {
        invertVec = false;
        angleOffset = 0;
        aimTransform = transform.Find("Aim");

        playerMove = GetComponent<PlayerMovement>();
        phase = -1;

    }

    public void AttackPhase()
    {
        done = 0;
        AttackSword();
    }

    public void RotationUpdate()
    {
       _currentRotation = aimTransform.rotation;
       aimTransform.rotation = Quaternion.Lerp(_currentRotation, _targetRotation, timeCount * rotatespeed);
       timeCount += Time.deltaTime;
    }
    public void AttackUpdate()
    {
        Vector3 mousePosition = GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position);
        angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        angle += angleOffset;
        //MAYBE CHANGE SCALE THEN ROTATE//

        //Debug.Log(invertVec);
        angle = angle + 45;
        //if (invertVec) { angle = -angle; }

        _targetRotation = Quaternion.Euler(0, 0, angle);

        //aimTransform.rotation = Quaternion.Euler(0, 0, angle);

        //aimTransform.eulerAngles = new Vector3(0, 0, angle);
    }

    public void WeaponAiming()
    {
        Vector3 mousePosition = GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position);
        angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        if (angle > 40 || angle < -100)
        {
            invertVec = true;
        }
        else
        {
            invertVec = false;
        }
    }

    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 0f;
        return worldPosition;
    }

    public void AttackSword()
    {
        if (phase == 0 | phase == -1)
        {
            lastAttackRot = -1;
            Vector3 mousePosition = GetMouseWorldPosition();

            Vector3 aimDirection = (mousePosition - transform.position).normalized;
            angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

            _targetRotation = Quaternion.Euler(0, 0, angle);

            //aimTransform.rotation = Quaternion.Euler(0, 0, angle);
            //aimTransform.eulerAngles = new Vector3(0, 0, angle);

            lastAttackRot = Time.time;

            phase = 1;
            done = 1;
        }
        if (phase == 1 && done != 1 )
        {
            Vector3 mousePosition = GetMouseWorldPosition();

            Vector3 aimDirection = (mousePosition - transform.position).normalized;
            angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

            _targetRotation = Quaternion.Euler(0, 0, angle);

            //aimTransform.rotation = Quaternion.Euler(0, 0, angle);
            //aimTransform.eulerAngles = new Vector3(0, 0, angle);

            phase = 0;

            
            Debug.Log("phase 2");
        }

    }
}
