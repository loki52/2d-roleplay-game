using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest 
{
    public string questName;
    public string questText;

    public Quest (string name, string description)
    {
        questName = name;
        questText = description;
    }
}
