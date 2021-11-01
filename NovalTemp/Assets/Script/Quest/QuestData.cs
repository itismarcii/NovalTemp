[System.Serializable] public class QuestData
{
    public string DataName;
    public string QuestName;
    public bool Finished;

    public QuestData(Quest quest)
    {
        DataName = quest.name;
        Finished = quest.Finished;
    }
}