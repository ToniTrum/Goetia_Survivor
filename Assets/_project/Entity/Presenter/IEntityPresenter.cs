using UnityEngine;

public interface IEntityPresenter
{
    public bool IsAlive { get; }
    public void TakeDamage(int damage);
    public void DealDamage();
}
