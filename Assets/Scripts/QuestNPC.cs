using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestNPC : Interactable
{
    [SerializeField] public UI_Quest uiQuest;

    public string questTitle;
    public string questText;

    public Quest questOne;

    private void Start()
    {
        //questOne = new Quest(questTitle, questText);
        uiQuest.SetQuest(questOne);
    }

    public override void OnInteract(GameObject player)
    {
        uiQuest.ShowQuest();
    }

    public override void StopInteract(GameObject player)
    {
        player.GetComponent<MouseInteract>().StopInteracting(this.gameObject);
        uiQuest.HideQuest();
    }
}


