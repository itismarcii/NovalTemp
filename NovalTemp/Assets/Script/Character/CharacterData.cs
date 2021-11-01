[System.Serializable] public class CharacterData
{
    public string DataName;
    public string CharacterName;
    public int QuestProgress = 0;
    public string Description;

    public Character.Categories[] Hobbies;
    public Character.Categories[] Likes;
    public Character.Categories[] Dislikes;
    public int Happy = 0;


    public CharacterData(Character character)
    {
        DataName = character.name;
        CharacterName = character.CharacterName;
        QuestProgress = character.QuestProgress;
        Description = character.Description;
        Hobbies = character.Hobbies;
        Likes = character.Likes;
        Dislikes = character.Dislikes;
        Happy = character.Happy;
    }
}