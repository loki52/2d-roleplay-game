using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteract : MonoBehaviour
{
    public float interactDistance = 0.4f;
    public float interactDistanceOffset = 0.1f;

    private RaycastHit2D[] rayHit = new RaycastHit2D[5];
    public ContactFilter2D mouseFilter;

    public bool isInteracting { get; private set; }
    public GameObject isInteractingWith { get; private set; }


    private void Start()
    {
        isInteracting = false;
    }

    private void Update()
    {
        if (isInteracting == true)
        {
            if (Vector2.Distance(transform.position, isInteractingWith.gameObject.transform.position) > interactDistance + interactDistanceOffset)
            {
                isInteractingWith.GetComponent<Interactable>().StopInteract(this.gameObject);
                //GetComponent<Player>().uiInventory.gameObject.SetActive(true);
            }
        }
        //else { GetComponent<Player>().uiInventory.gameObject.SetActive(false); }
    }

    public void RayInteract()
    {
        //Interactable mouse raycast
        Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, mouseFilter, rayHit);
        int rayIndex = FindRayIndex(rayHit);
        if (rayIndex != -1 && isInteracting == false)
        {
            if (Vector2.Distance(transform.position, rayHit[rayIndex].collider.gameObject.transform.position) < interactDistance)
            {
                isInteracting = true;
                isInteractingWith = rayHit[rayIndex].collider.gameObject;
                rayHit[rayIndex].collider.gameObject.GetComponent<Interactable>().OnInteract(this.gameObject);
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

    public void StopInteracting(GameObject interactionGameObject)
    {
        if (interactionGameObject == isInteractingWith)
        {
            isInteracting = false;
        }
        Debug.Log("Stopped interacting");
    }


    public void ExitButtonClick()
    {
        isInteractingWith.GetComponent<Interactable>().StopInteract(this.gameObject);
        isInteracting = false;
    }


}
