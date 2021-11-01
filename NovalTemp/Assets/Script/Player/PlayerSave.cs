using UnityEngine;

public class PlayerSave : MonoBehaviour
{
    public const string KEY_PLAYER = "Player";

    private void Awake()
    {
        GameManager.SaveData += Save;
        GameManager.LoadData += Load;
    }

    PlayerData ConvertPlayer(Player player)
    {

        PlayerData playerData = new PlayerData(player);

        return playerData;
    }

    void ConvertPlayerData(PlayerData playerData)
    {
        Player player = Resources.Load<Player>("Player/Player");

        player.name = playerData.DataName;
        player.CharacterName = playerData.CharacterName;
        player.Fitness = playerData.Fitness;
        player.Intelligence = playerData.Intelligence;
        player.Fame = playerData.Fame;
        player.Charisma = playerData.Charisma;
        player.Money = playerData.Money;

    }

    private void Save()
    {
        Player player = Resources.Load<Player>("Player/Player");
        SaveLoad.Save<PlayerData>(ConvertPlayer(player), KEY_PLAYER);
    }

    private void Load()
    {
        if (SaveLoad.SaveExists(KEY_PLAYER))
            ConvertPlayerData(SaveLoad.Load<PlayerData>(KEY_PLAYER));
    }
}
