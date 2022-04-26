using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Death : MonoBehaviour
{
    private void Awake()
    {
        this.gameObject.SetActive(false);
    }

    public void PlayerDeath()
    {
        Debug.Log("here");
        this.gameObject.SetActive(true);
    }

    public void ResatrtScene()
    {
        SceneManager.LoadScene("Dungeon1");
    }
}
