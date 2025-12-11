using UnityEngine;

public class EnemyPresenter : IEntityPresenter
{
    EnemyModel _model;

    public void TakeDamage(int damage)
    {
        _model.TakeDamage(damage);
    }

    public void DealDamage(Entity player, int damage)
    {
        player.TakeDamage(damage);
    }
}
