using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void OnInteract(GameObject player)
    {
    }
    
    public virtual void StopInteract(GameObject player)
    {
        player.GetComponent<MouseInteract>().StopInteracting(this.gameObject);
    }
}