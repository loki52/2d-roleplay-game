using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Quest : MonoBehaviour
{
    private Quest currentQuest;

    private Text questTitle;
    private Text questText;

    public AudioSource audiodata;
    public AudioClip closeQuest;

    public AudioManager audioManager;
    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        Transform questTitleTransform = transform.Find("questTitle");
        Transform questTextTransform = transform.Find("questText");
        questTitle = questTitleTransform.GetComponent<Text>();
        questText = questTextTransform.GetComponent<Text>();
    }

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void SetQuest(Quest quest)
    {
        currentQuest = quest;
        UpdateUI();
    }

    public void ShowQuest()
    {
        this.gameObject.SetActive(true);
        audioManager.Play("OpenQuest");
    }

    public void HideQuest()
    {
        this.gameObject.SetActive(false);
        audioManager.Play("CloseQuest");
    }


    private void UpdateUI()
    {
        questTitle.text = currentQuest.questName;
        questText.text = currentQuest.questText;
    }
}
