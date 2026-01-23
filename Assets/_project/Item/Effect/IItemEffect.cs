using UnityEngine;

public abstract class ItemEffect : ScriptableObject
{
    public abstract void Apply(PlayerModel model);
    public abstract string GetDescription();
}