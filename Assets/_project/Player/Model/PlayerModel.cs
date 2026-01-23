using System;
using System.Diagnostics.Tracing;
using Unity.Mathematics;

public class PlayerModel : IEntityModel
{
    public event Action<int> OnHealthChanged;
    public event Action<int> OnMaxHealthChanged;
    public event Action<int> OnGoldChanged;
    public event Action<float> OnSpeedChanged;

    private int _maxHealth;
    private int _health;
    private int _gold;
    private float _speed;

    public int MaxHealth 
    { 
        get => _maxHealth; 
        set
        {
            if(_maxHealth != value)
            {
                _maxHealth = value;
                OnMaxHealthChanged?.Invoke(_maxHealth);
            }
        } 
    }
    public int Health
    {
        get => _health;
        set
        {
            if(_health != value)
            {
                _health = value;
                OnHealthChanged?.Invoke(_health);
            }
        }
    }
    public float Speed
    {
        get => _speed;
        set
        {
           if(_speed != value)
            {
                _speed = value;
                OnSpeedChanged?.Invoke(_speed);
            } 
        }
    }
    public float DashSpeed { get; set; } 
    public float DashDuration { get; set; } 
    public float DashCooldown { get; set; }
    public bool IsAlive => Health > 0;
    public int Gold
    {
        get => _gold;
        set
        {
            if(_gold != value)
            {
                _gold = value;
                OnGoldChanged?.Invoke(_gold);
            }
        }
    }

    public Inventory Inventory { get; }

    public void TakeDamage(int damage)
    {
        Health = math.max(0, Health - damage);
    }

    public PlayerModel(int maxHealth, float speed, float dashSpeed, float dashDuration, float dashCooldown, int gold)
    {
        MaxHealth = maxHealth;
        Health = maxHealth;
        Speed = speed;
        DashSpeed = dashSpeed;
        DashDuration = dashDuration;
        DashCooldown = dashCooldown;
        Gold = gold;

        Inventory = new Inventory();
    }

    public void AddGold(int value)
    {
        Gold += value;
    }

    public bool TrySpendGold(int value)
    {
        return Gold >= value;
    }

    public void SpendGold(int value)
    {
        if(TrySpendGold(value))
        {
            Gold -= value;
        }
    }
}