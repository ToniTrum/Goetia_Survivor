using Unity.Mathematics;

public class PlayerModel : IEntityModel
{
    public int MaxHealth { get; set; }
    public int Health { get; set; }
    public float Speed { get; set; }
    public bool IsAlive => Health > 0;

    public void TakeDamage(int damage)
    {
        Health = math.max(0, Health - damage);
    }

    public PlayerModel(float speed)
    {
        Speed = speed;
    }
}