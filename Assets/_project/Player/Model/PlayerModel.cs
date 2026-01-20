using Unity.Mathematics;

public class PlayerModel : IEntityModel
{
    public int MaxHealth { get; set; }
    public int Health { get; set; }
    public float Speed { get; set; }
    public float Range { get; set; }

    public float DashSpeed { get; set; } 
    public float DashDuration { get; set; } 
    public float DashCooldown { get; set; }
    public bool IsAlive => Health > 0;

    public void TakeDamage(int damage)
    {
        Health = math.max(0, Health - damage);
    }

    public PlayerModel(int maxHealth, float speed, float range, float dashSpeed, float dashDuration, float dashCooldown)
    {
        MaxHealth = maxHealth;
        Health = maxHealth;
        Speed = speed;
        Range = range;

        DashSpeed = dashSpeed;
        DashDuration = dashDuration;
        DashCooldown = dashCooldown;
    }
}