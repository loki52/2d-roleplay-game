using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    private MouseInteract mouseInteract;

    private void Start()
    {
        mouseInteract = GetComponent<MouseInteract>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Attack mouse raycast

        }

        if (Input.GetMouseButtonDown(1))
        {
            mouseInteract.RayInteract();
        }
    }
}
