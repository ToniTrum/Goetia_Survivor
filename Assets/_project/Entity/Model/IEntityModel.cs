using UnityEngine;

public interface IEntityModel
{
    public int MaxHealth { get; }
    public int Health { get; }
    public float Speed { get; }
}