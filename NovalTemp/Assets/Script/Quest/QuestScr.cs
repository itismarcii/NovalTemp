using System.Collections.Generic;
using UnityEngine;

public class QuestScr : MonoBehaviour
{
    QuestManager QuestManager;
    public Quest Quest;
    List<string> keys = new List<string>();
    public VoidEvent finishedGameEvent;

    private void Awake()
    {
        QuestManager = FindObjectOfType<QuestManager>();
    }

    public QuestScr(Quest quest)
    {
        Quest = quest;

        foreach (string str in quest.Requirements.DictionaryKeys)
        {
            keys.Add(str);
        }
    }

    public void FinishQuestReqirement(Character questCharacter)
    {
        for (int i = keys.Count - 1; i >= 0; i--)
        {
            if (keys[i].Contains(questCharacter.name))
            {
                bool boolean;

                if (Quest.Requirements.BoolDictionary.TryGetValue(keys[i], out boolean))
                {
                    boolean = true;
                    keys.Remove(keys[i]);

                    if (keys.Count <= 0)
                    {
                        FinishedQuest();
                    }
                }
            }
        }
    }

    public void FinishQuestReqirement(GameObject questItem)     //Gameobject == Item <- from Inventory
    {
        for (int i = keys.Count - 1; i >= 0; i--)
        {
            if (keys[i].Contains(questItem.name))
            {
                bool boolean;

                if (Quest.Requirements.BoolDictionary.TryGetValue(keys[i], out boolean))
                {
                    boolean = true;
                    keys.Remove(keys[i]);

                    if (keys.Count <= 0)
                    {
                        FinishedQuest();
                    }
                }
            }
        }
    }

    public bool CheckRequirementsFinished()
    {
        int counter = 0;

        bool boolean;

        foreach (string key in Quest.Requirements.DictionaryKeys)
        {
            if (Quest.Requirements.BoolDictionary.TryGetValue(key, out boolean))
            {
                if (boolean) { counter++; }
            }
        }

        if (counter == Quest.Requirements.DictionaryKeys.Count)
        {
            FinishedQuest();
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool ExistsRequirmentCharacter(Character character, Quest quest)
    {
        foreach (Character chara in QuestManager.FindRequirments(quest).TalkTo)
        {
            if (character.name == chara.name)
            {
                return true;
            }
        }

        return false;
    }

    public Character RequirmentCharacter(Character character, Quest quest)
    {
        foreach (Character chara in QuestManager.FindRequirments(quest).TalkTo)
        {
            if (character.name == chara.name)
            {
                return chara;
            }
        }

        return null;
    }

    public bool ExistsRequirmentItem(GameObject item, Quest quest)
    {
        foreach (GameObject it in QuestManager.FindRequirments(quest).Items)
        {
            if (item.name == it.name)
            {
                return true;
            }
        }

        return false;
    }

    public GameObject RequirmentItem(GameObject item, Quest quest)
    {
        foreach (GameObject it in QuestManager.FindRequirments(quest).Items)
        {
            if (item.name == it.name)
            {
                return it;
            }
        }

        return null;
    }

    public void FinishedQuest()
    {
        Quest.Character.QuestProgress++;
        Quest.Finished = true;
        finishedGameEvent.Raise();
    }
}