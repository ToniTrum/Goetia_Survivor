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

    public float GetRange()
    {
        return Model.Range;
    }

    public float GetSpeed()
    {
        return Model.Speed;
    }

    public float GetAttackCooldown()
    {
        return Model.AttackCooldown;
    }

    public float GetAttackOffset()
    {
        return Model.AttackOffset;
    }
}
