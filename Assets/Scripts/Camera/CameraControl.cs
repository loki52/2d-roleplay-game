using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Player player;

    private void Update()
    {
        Vector3 newPos = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        transform.position = newPos;
    }
}
