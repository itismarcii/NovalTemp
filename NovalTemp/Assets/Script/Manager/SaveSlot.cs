using System.Collections.Generic;
using UnityEngine;

public class SaveSlot : MonoBehaviour
{
    public static List<SaveSlot> slotList = new List<SaveSlot>();

    SaveSlot()
    {
        slotList.Add(this);
    }

    public string SaveSlotName;
    public string SlotPath;
    public string PlayerKey;
    public string CharacterKey;
    public string QuestKey;
    public string itemKey;
}