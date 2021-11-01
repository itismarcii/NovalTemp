using UnityEngine;

public class PlayerScr : MonoBehaviour
{
    //public static PlayerScr Instantiate { get; set; }

    public Player Player;
    public int nameMaxChar = 18;

    private void Awake()
    {
        //if(Instantiate == null) { Instantiate = this; DontDestroyOnLoad(gameObject); } else { Destroy(gameObject); }

        GameManager.NewGame += NewGame;

        Player = Resources.Load<Player>("Player/Player");
    }

    private void NewGame()
    {
        Player.SetDefault();
    }

    public void SetCharacterName(string name)
    {
        if (name.Length <= nameMaxChar)
        {
            Player.CharacterName = name;
        }
        else
        {
            Debug.Log("Name to many chars");
        }
    }

    public int IncreaseAttribute(string attributeName, int value)
    {
        switch (attributeName)
        {
            case "Fitness":
                return Player.Money += value;
            case "Intelligence":
                return Player.Money += value;
            case "Fame":
                return Player.Money += value;
            case "Charisma":
                return Player.Charisma += value;
            case "Money":
                return Player.Money += value;
            default:
                return 0;
        }
    }

    public void AddItem(GameObject item)
    {
        Player.Itemlist.Add(item);
    }

    public void RemoveItem(GameObject item)
    {
        Player.Itemlist.Remove(item);
    }
}