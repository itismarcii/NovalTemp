using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Character : ScriptableObject
{
    private void OnEnable() => CharacterName = name;

    [System.NonSerialized] public string CharacterName = "";
    [System.NonSerialized] public int QuestProgress = 0;
    [System.NonSerialized] public string Description = "";

    public Categories[] Hobbies;
    public Categories[] Likes;
    public Categories[] Dislikes;

    [System.NonSerialized] public int Happy = 0;

    public enum Categories
    {
        Sport,
        Beauty,
        Games,
        Food,
        Art,
        Music,
        Technik
    }

    public void SetDefault()
    {
        QuestProgress = 0;
        Happy = 0;
    }
}