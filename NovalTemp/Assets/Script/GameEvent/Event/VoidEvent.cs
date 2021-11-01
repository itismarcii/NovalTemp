using UnityEngine;

[CreateAssetMenu(fileName = "New Void Event", menuName = "GameEvent/Void")]
public class VoidEvent : BaseGameEvent<Void>
{
    public void Raise() => Raise(new Void());
}