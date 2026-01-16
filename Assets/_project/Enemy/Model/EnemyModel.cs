using UnityEngine;

public class EnemyModel : IEntityModel
{
    public int MaxHealth { get; private set; }
    public int Health { get; private set; }
    public float Speed { get; private set; }
    public bool IsAlive => Health > 0;

    public EnemyModel(EnemyConfig enemyBaseModel)
    {
        MaxHealth = enemyBaseModel.BaseMaxHealth;
        Health = MaxHealth;
        Speed = enemyBaseModel.BaseSpeed;
    }

    public void TakeDamage(int damage)
    {
        Health = Mathf.Max(0, Health - damage);
    }
}
