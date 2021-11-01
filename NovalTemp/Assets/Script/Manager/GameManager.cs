using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    //Prefabs
    public GameObject PlayerPrefab;

    //Save && Load
    public static System.Action SaveData;
    public static System.Action LoadData;
    public static System.Action DeleteSaveData;

    //NewGame
    public static System.Action NewGame;

    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); } else { Destroy(gameObject); }

        if (!FindObjectOfType<PlayerScr>())
        {
            GameObject player = Instantiate(PlayerPrefab);
            PlayerScr playerScr = player.GetComponent<PlayerScr>();
            playerScr.Player.SetDefault();
            player.name = playerScr.Player.name;
        }
    }



    public static void OnSave()
    {
        SaveData?.Invoke();
    }

    public static void OnLoad()
    {
        LoadData?.Invoke();
    }

    public static void OnDeleteSaveData()
    {
        DeleteSaveData?.Invoke();
    }

    public static void OnNewGame()
    {
        NewGame?.Invoke();
    }
}
