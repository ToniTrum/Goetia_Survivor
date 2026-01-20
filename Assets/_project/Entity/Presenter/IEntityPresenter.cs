using UnityEngine;

public interface IEntityPresenter
{
    void TakeDamage(int damage);
    void DealDamage(IEntity entity, int damage);
    
    int GetMaxHealth();
    int GetHealth();
    float GetSpeed();
    float GetRange();
    float GetAttackCooldown();
}
