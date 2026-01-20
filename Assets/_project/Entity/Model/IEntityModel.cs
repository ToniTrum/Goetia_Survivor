using UnityEngine;

public interface IEntityModel
{
    public int MaxHealth { get; }
    public int Health { get; }
    public float Speed { get; }
    public float Range { get; }
    public bool IsAlive { get; }

    public void TakeDamage(int damage);
}