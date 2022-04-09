using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{

    private RaycastHit2D[] rayHit = new RaycastHit2D[5];
    public ContactFilter2D mouseFilter;

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //Attack mouse raycast

        }

        if (Input.GetMouseButtonDown(1))
        {
            //Interactable mouse raycast
            Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, mouseFilter, rayHit);
            int rayIndex = FindRayIndex(rayHit);
            if (rayIndex != -1)
            {
                if (Vector2.Distance(transform.position, rayHit[rayIndex].collider.gameObject.transform.position) < 0.9)
                {
                    rayHit[rayIndex].collider.gameObject.GetComponent<Interactable>().OnInteract(this.gameObject);
                }
            }
        }
    }
    private int FindRayIndex(RaycastHit2D[] hitList)
    {
        //finds the last element which has a collider
        int lowestI = -1;
        for (int i = 0; i < rayHit.Length; i++)
        {
            if (rayHit[i].collider != null) { lowestI = i; }
        }
        return lowestI;
    }
}
