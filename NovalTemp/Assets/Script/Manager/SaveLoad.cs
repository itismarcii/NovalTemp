using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public class SaveLoad : MonoBehaviour
{
    public static Dictionary<string, string> saveFiles = new Dictionary<string, string>();
    static List<string> keyLists = new List<string>();

    const string SAVE_LOCATION = "/saves/";
    static string mainPath;

    private void Awake()
    {
        GameManager.DeleteSaveData += DeleteAllSaves;

        mainPath = Application.persistentDataPath + SAVE_LOCATION;
        Directory.CreateDirectory(mainPath);
    }

    public static void Save<T>(T objectToSave, string key)
    {
        string path = mainPath + "save";

        if (!SaveSlotManager.Slot) { path = GenerateSavePath(key, path); }
        else { path = SaveSlotManager.Slot.SlotPath; }

        SaveSlotManager.AddKey(key);
        Directory.CreateDirectory(path);

        BinaryFormatter formatter = new BinaryFormatter();
        using FileStream filestream = new FileStream(path + key + ".txt", FileMode.Create);
        formatter.Serialize(filestream, objectToSave);
    }

    static string GenerateSavePath(string key, string path)
    {
        //Checks if the Key already exists inside the Dictionary saveFiles
        string CheckKey(string checkKey, int counter)
        {
            if (saveFiles.ContainsKey(checkKey))
            {
                string newKey = checkKey.Substring(0, key.Length) + counter;
                counter++;
                return CheckKey(newKey, counter);
            }
            else
            {
                return checkKey;
            }
        }

        string newKey = CheckKey(key, 0);
        keyLists.Add(newKey);

        int counter = 0;
        foreach (string str in keyLists)
        {
            if (str.Contains(key))
            {
                if (saveFiles.ContainsKey(str)) { counter++; }
                else
                {
                    if (counter == 0)
                    {
                        path += "/";
                        saveFiles.Add(newKey, path);
                        break;
                    }

                    path += " " + counter + "/";
                    saveFiles.Add(newKey, path);
                    break;
                }
            }
        }

        return path;
    }

    //Needs To be capable off loading the right path.
    public static T Load<T>(string key)
    {

        string path = SaveSlotManager.Slot.SlotPath;
        BinaryFormatter formatter = new BinaryFormatter();
        T returnValue = default;
        using (FileStream fileStream = new FileStream(path + key + ".txt", FileMode.Open))
        {
            returnValue = (T)formatter.Deserialize(fileStream);
        }

        return returnValue;
    }

    public static bool SaveExists(string key)
    {
        string path = Application.persistentDataPath + SAVE_LOCATION + key + ".txt";
        return File.Exists(path);
    }

    public static void DeleteAllSaves()
    {
        string path = Application.persistentDataPath + SAVE_LOCATION;
        DirectoryInfo directory = new DirectoryInfo(path);
        directory.Delete(true);
        Directory.CreateDirectory(path);
    }

}