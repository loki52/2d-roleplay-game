using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddEnemyTest : BoxCollision
{
    public GameObject enemyPrefab;
    float rx;
    float ry;
    bool triggered = false;

    private void spawnEnemy()
    {
        genRandomCoords();
        Instantiate(enemyPrefab, new Vector3(rx, ry, 0), Quaternion.identity);
        genRandomCoords();
        Instantiate(enemyPrefab, new Vector3(rx, ry, 0), Quaternion.identity);
        genRandomCoords();
        Instantiate(enemyPrefab, new Vector3(rx, ry, 0), Quaternion.identity);
        genRandomCoords();
        Instantiate(enemyPrefab, new Vector3(rx, ry, 0), Quaternion.identity);
        genRandomCoords();
        Instantiate(enemyPrefab, new Vector3(rx, ry, 0), Quaternion.identity);
        genRandomCoords();
        Instantiate(enemyPrefab, new Vector3(rx, ry, 0), Quaternion.identity);
    }

    private void genRandomCoords()
    {
        rx = Random.Range(1.357f, 2.636f);
        ry = Random.Range(0.883f, -0.8879f);
    }

    protected override void OnCollide(Collider2D collide)
    {
        if (collide != null && collide.tag == "Player" && triggered == false)
        {
            triggered = true;
            spawnEnemy();
        }
    }
}
