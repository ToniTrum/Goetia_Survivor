using UnityEngine;

public interface IEntityPresenter
{
    void TakeDamage(int damage);
    void DealDamage(Entity entity, int damage);
}
