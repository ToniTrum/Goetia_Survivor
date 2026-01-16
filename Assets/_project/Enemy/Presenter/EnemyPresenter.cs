using Zenject;

public class EnemyPresenter : IEntityPresenter
{
    [Inject] protected EnemyModel Model { get; private set; }

    public void TakeDamage(int damage)
    {
        Model.TakeDamage(damage);
    }

    public void DealDamage(IEntity player, int damage)
    {
        player.TakeDamage(damage);
    }

    public int GetMaxHealth()
    {
        return Model.MaxHealth;
    }

    public int GetHealth()
    {
        return Model.Health;
    }
}
