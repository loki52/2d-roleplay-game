using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
     public void OnInteract(GameObject player)
    {
        Debug.Log("Interacting, I am, " + this.name);
    }
}
