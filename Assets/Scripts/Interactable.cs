using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void OnInteract(GameObject player)
    {
        Debug.Log("Interacting, I am, " + this.name);
    }
    
    public virtual void StopInteract(GameObject player)
    {
        player.GetComponent<MouseInteract>().StopInteracting(this.gameObject);
        Debug.Log("STOP INTERACT");
    }
}