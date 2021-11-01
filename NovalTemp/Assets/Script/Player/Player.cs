using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Player")]
public class Player : ScriptableObject
{
    private void OnEnable() => this.name = "Player";

    [System.NonSerialized] public string CharacterName;
    [System.NonSerialized] public int Fitness = 0;
    [System.NonSerialized] public int Intelligence = 0;
    [System.NonSerialized] public int Fame = 0;
    [System.NonSerialized] public int Charisma = 0;
    [System.NonSerialized] public int Money = 0;
    [System.NonSerialized] public List<GameObject> Itemlist;

    public void SetDefault()
    {
        CharacterName = "";
        Fitness = 0;
        Intelligence = 0;
        Fame = 0;
        Charisma = 0;
        Money = 0;
        //itemList = itemList;
    }
}