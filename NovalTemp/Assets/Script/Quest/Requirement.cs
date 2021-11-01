using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Requirement
{
    private void OnEnable()
    {
        PrepareBools();
    }

    private void PrepareBools()
    {
        int counter = 0;

        foreach (Character character in TalkTo)
        {
            if (!BoolDictionary.ContainsKey(character.name))
            {
                BoolDictionary.Add(character.name, false);
                DictionaryKeys.Add(character.name);

            }
            else
            {
                BoolDictionary.Add(character.name + counter.ToString(), false);
                DictionaryKeys.Add(character.name + counter);
                counter++;
            }
        }

        counter = 0;

        foreach (GameObject item in Items)
        {
            if (!BoolDictionary.ContainsKey(item.name))
            {
                BoolDictionary.Add(item.name, false);
                DictionaryKeys.Add(item.name);
            }
            else
            {
                BoolDictionary.Add(item.name + counter, false);
                DictionaryKeys.Add(item.name + counter);
                counter++;
            }
        }
    }

    public Character[] TalkTo;
    [System.NonSerialized] public Dictionary<string, bool> BoolDictionary = new Dictionary<string, bool>();
    [System.NonSerialized] public List<string> DictionaryKeys = new List<string>();
    public GameObject[] Items;
}
