using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static Dictionary<string, List<Quest>> QuestDictionary = new Dictionary<string, List<Quest>>();

    public GameObject questPrefab;

    private void Awake()
    {
        GameManager.NewGame += NewGame;
    }

    private void NewGame()
    {
        if (transform.childCount > 0)
        {
            foreach (var child in transform.GetComponentsInChildren<QuestScr>())
            {
                Destroy(child);
            }
        }

        Character[] characters = Resources.LoadAll<Character>("Character");
        foreach (Character character in characters)
        {
            Quest[] quests = Resources.LoadAll<Quest>("Quest/" + character.name);

            foreach (Quest quest in quests)
            {
                quest.Finished = false;
            }
        }

        FillQuestList();
    }

    public Requirement FindRequirments(Quest quest)
    {
        List<Quest> QuestList;

        if (QuestDictionary.TryGetValue(quest.name, out QuestList))
        {
            foreach (Quest qu in QuestList)
            {
                if (quest.name == qu.name)
                {
                    return qu.Requirements;
                }
            }
        }

        return null;
    }

    public void FillQuestList()
    {
        QuestDictionary.Clear();

        foreach (Character character in CharacterSave.Characters)
        {
            Quest[] questArray = Resources.LoadAll<Quest>("Quest/" + character.name.ToString());
            List<Quest> quests = new List<Quest>();

            for (int i = 0; i < questArray.Length; i++)
            {
                if (!quests.Contains(questArray[i]))
                {
                    quests.Add(questArray[i]);
                }
            }

            QuestDictionary.Add(character.name.ToString(), quests);
        }

        Quest[] questArrayMain = Resources.LoadAll<Quest>("Quest/" + "Main");
        List<Quest> questsMain = new List<Quest>();

        for (int i = 0; i < questArrayMain.Length; i++)
        {
            questsMain.Add(questArrayMain[i]);
        }

        QuestDictionary.Add("Main", questsMain);

    }

    public Quest ActiveQuest(Character character)
    {
        List<Quest> questList;

        if (QuestDictionary.TryGetValue(character.name.ToString(), out questList))
        {
            foreach (Quest quest in questList)
            {
                if (character.QuestProgress == quest.QuestNumber) { return quest; }
            }
        }

        Debug.LogWarning("QuestError: No Quests under that Key !!!");
        return null;
    }

    public void ActivateQuest(Quest quest)
    {
        bool unique = true;

        if (transform.childCount > 0)
        {
            foreach (QuestScr questScripts in transform.GetComponentsInChildren<QuestScr>())
            {
                if (questScripts.name == quest.name)
                {
                    unique = false;
                }
            }
        }

        if (unique)
        {
            GameObject questObject = Instantiate(questPrefab, gameObject.transform);
            questObject.GetComponent<QuestScr>().Quest = quest;
            questObject.name = quest.name;
        }
    }
}