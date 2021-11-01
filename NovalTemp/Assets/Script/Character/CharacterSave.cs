using System.Collections.Generic;
using UnityEngine;

public class CharacterSave : MonoBehaviour
{
    public static List<Character> Characters { get; set; } = new List<Character>();
    public const string KEY_CHARACTER = "Character";

    private void Awake()
    {
        GameManager.SaveData += Save;
        GameManager.LoadData += Load;
        GameManager.NewGame += NewGame;

        FillCharaters();
    }

    private void FillCharaters()
    {
        Characters.Clear();

        Character[] chars = Resources.LoadAll<Character>(KEY_CHARACTER);
        foreach (Character car in chars)
        {
            if (!Characters.Contains(car))
                Characters.Add(car);
        }

        FindObjectOfType<QuestManager>().FillQuestList();
    }

    private void NewGame()
    {
        Character[] characters = Resources.LoadAll<Character>("Character");
        foreach (Character character in characters)
        {
            character.SetDefault();
        }

        FillCharaters();
    }

    private void AddCharater(List<CharacterData> characters)
    {
        Character[] chars = Resources.LoadAll<Character>(KEY_CHARACTER);
        foreach (CharacterData charData in characters)
        {
            foreach (Character character in chars)
            {
                if (charData.DataName == character.name)
                {
                    character.CharacterName = charData.CharacterName;
                    character.QuestProgress = charData.QuestProgress;
                    character.Description = charData.Description;
                    character.Hobbies = charData.Hobbies;
                    character.Likes = charData.Likes;
                    character.Dislikes = charData.Dislikes;
                    character.Happy = charData.Happy;
                }
            }
        }
    }

    List<CharacterData> ConvertCharacters()
    {
        List<CharacterData> charData = new List<CharacterData>();
        Character[] chars = Resources.LoadAll<Character>(KEY_CHARACTER);
        foreach (Character character in chars)
        {
            CharacterData characterData = new CharacterData(character);
            charData.Add(characterData);
        }

        return charData;
    }

    private void Save()
    {
        SaveLoad.Save<List<CharacterData>>(ConvertCharacters(), KEY_CHARACTER);
    }

    private void Load()
    {
        if (SaveLoad.SaveExists(KEY_CHARACTER))
            AddCharater(SaveLoad.Load<List<CharacterData>>(KEY_CHARACTER));
    }
}