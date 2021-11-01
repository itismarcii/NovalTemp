using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSlotManager : MonoBehaviour
{
    public static SaveSlot Slot;

    public void SelectSlot(SaveSlot slot)
    {
        Slot = slot;
    }

    public void DeSelectSlot()
    {
        Slot = null;
    }

    public static void AddKey(string Key)
    {
        if (Slot)
        {
            switch (Key)
            {
                case QuestSave.KEY_QUEST:
                    Slot.QuestKey = Key;
                    break;
                case CharacterSave.KEY_CHARACTER:
                    Slot.CharacterKey = Key;
                    break;
                case PlayerSave.KEY_PLAYER:
                    Slot.PlayerKey = Key;
                    break;
            }
        }
    }

}
