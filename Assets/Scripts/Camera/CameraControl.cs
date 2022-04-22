using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject target;

    private bool targetDeath;

    private void Update()
    {
        if (targetDeath == false)
        {
            if (target.GetComponent<Entity>().Death == true) { targetDeath = true; }
            Vector3 newPos = new Vector3(target.transform.position.x, target.transform.position.y, -10);
            transform.position = newPos;
        }
    }
}