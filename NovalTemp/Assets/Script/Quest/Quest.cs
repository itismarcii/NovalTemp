using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest/Quest")]
public class Quest : ScriptableObject
{
    private void OnEnable()
    {
        QuestName = name;
    }

    [System.NonSerialized] public string QuestName;
    public int QuestNumber;
    [Space]
    public Character Character;
    [TextArea] public string Description;
    [TextArea] public string QuestWalkthrough;

    [Space]
    public Requirement Requirements;
    [System.NonSerialized] public bool Finished = false;
}
