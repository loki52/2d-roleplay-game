using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "QuestInstance/Quest")]
public class Quest : ScriptableObject
{
    public string questName;
    public string questText;

    protected virtual void QuestCompleted()
    {

    }
}
