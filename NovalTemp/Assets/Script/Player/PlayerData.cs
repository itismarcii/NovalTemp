[System.Serializable] public class PlayerData
{
    public string DataName;
    public string CharacterName;
    public int Fitness;
    public int Intelligence;
    public int Fame;
    public int Charisma;
    public int Money;


    public PlayerData(Player player)
    {
        DataName = player.name;
        CharacterName = player.CharacterName;
        Fitness = player.Fitness;
        Intelligence = player.Intelligence;
        Fame = player.Fame;
        Charisma = player.Charisma;
        Money = player.Money;
    }
}