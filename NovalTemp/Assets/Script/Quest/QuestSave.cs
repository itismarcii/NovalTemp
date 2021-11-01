using System.Collections.Generic;
using UnityEngine;

public class QuestSave : MonoBehaviour
{
    public static List<Quest> Quests { get; set; } = new List<Quest>();
    public const string KEY_QUEST = "Quest";

    private void Awake()
    {
        GameManager.SaveData += Save;
        GameManager.LoadData += Load;

        FillQuests();
    }
    void FillQuests()
    {
        foreach (Character character in CharacterSave.Characters)
        {
            Quest[] quests = Resources.LoadAll<Quest>(KEY_QUEST + "/" + character.name);
            foreach (Quest quest in quests)
            {
                Quests.Add(quest);
            }
        }
    }

    void AddQuest(List<QuestData> quests)
    {
        foreach (Character character in CharacterSave.Characters)
        {
            Quest[] questCharacterLists = Resources.LoadAll<Quest>(KEY_QUEST + "/" + character.name);

            foreach (QuestData questData in quests)
            {
                foreach (Quest quest in questCharacterLists)
                {
                    if (quest.name == questData.DataName)
                    {
                        quest.Character = Resources.Load<Character>("Character/" + questData.DataName);
                        quest.Finished = questData.Finished;
                    }
                }
            }
        }
    }

    List<QuestData> ConvertQuests()
    {
        List<QuestData> questDatas = new List<QuestData>();

        foreach (Character character in CharacterSave.Characters)
        {
            Quest[] questList = Resources.LoadAll<Quest>(KEY_QUEST + "/" + character.name);
            foreach (Quest quest in questList)
            {
                QuestData questData = new QuestData(quest);
                questDatas.Add(questData);
            }
        }

        return questDatas;
    }

    private void Save()
    {
        SaveLoad.Save<List<QuestData>>(ConvertQuests(), KEY_QUEST);
    }

    private void Load()
    {
        if (SaveLoad.SaveExists(KEY_QUEST))
        {
            AddQuest(SaveLoad.Load<List<QuestData>>(KEY_QUEST));
        }
    }
}