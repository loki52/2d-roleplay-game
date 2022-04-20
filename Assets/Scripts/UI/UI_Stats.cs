using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Stats : MonoBehaviour
{
    private Player currentPlayer;

    private Text healthText;
    private void Awake()
    {
        Transform healthTransform = transform.Find("Health");
        healthText = healthTransform.GetComponent<Text>();
    }

    private void Start()
    {
        this.gameObject.SetActive(true);
    }

    public void SetPlayer(Player player)
    {
        currentPlayer = player;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (currentPlayer.healthPoints < 50) { healthText.color = Color.red; }
        else { healthText.color = Color.white; }
        healthText.text = "Health: " + currentPlayer.healthPoints.ToString();
    }
}
