using UnityEngine;

public class ProjectileModel
{
    public float Speed { get; private set; }
    public int Damage { get; private set; }

    public ProjectileModel(ProjectileConfig projectileConfig)
    {
        Speed = projectileConfig.BaseSpeed;
        Damage = projectileConfig.BaseDamage;
    }
}
