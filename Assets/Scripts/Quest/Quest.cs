using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : ScriptableObject
{
    public string questName;
    public string questText;

    public Quest (string name, string description)
    {
        questName = name;
        questText = description;
    }

    protected virtual void QuestCompleted()
    {

    }
}
