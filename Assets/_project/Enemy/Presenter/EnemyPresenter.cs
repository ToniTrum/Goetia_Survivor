using Zenject;

public class EnemyPresenter : IEntityPresenter
{
    [Inject] private EnemyModel _model;

    public void TakeDamage(int damage)
    {
        _model.TakeDamage(damage);
    }

    public void DealDamage(IEntity player, int damage)
    {
        player.TakeDamage(damage);
    }

    public int GetMaxHealth()
    {
        return _model.MaxHealth;
    }

    public int GetHealth()
    {
        return _model.Health;
    }
}
