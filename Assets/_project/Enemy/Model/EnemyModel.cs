using UnityEngine;

public class EnemyModel : IEntityModel
{
    public int MaxHealth { get; private set; }
    public int Health { get; private set; }
    public float Speed { get; private set; }
    public float Range { get; private set; }
    public float AttackCooldown { get; private set; }

    public bool IsAlive => Health > 0;

    public EnemyModel(EnemyConfig enemyConfig)
    {
        MaxHealth = enemyConfig.BaseMaxHealth;
        Health = MaxHealth;
        Speed = enemyConfig.BaseSpeed;
        Range = enemyConfig.BaseRange;
        AttackCooldown = enemyConfig.BaseAttackCooldown;
    }

    public void TakeDamage(int damage)
    {
        Health = Mathf.Max(0, Health - damage);
    }
}
