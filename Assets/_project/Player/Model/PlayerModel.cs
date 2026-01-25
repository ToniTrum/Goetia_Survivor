using System;
using System.Diagnostics.Tracing;
using UnityEngine;

public class PlayerModel : IEntityModel
{
    public static float HEALTH_REGEN_INTERVAL = 1f;
    public static float STAMINA_REGEN_INTERVAL = 0.2f;
    public event Action<int> OnMaxHealthChanged;
    public event Action<int> OnHealthChanged;
    public event Action<int> OnHealthRegenerationChanged;
    public event Action<int> OnMaxStaminaChanged;
    public event Action<int> OnStaminaChanged;
    public event Action<int> OnStaminaRegenerationChanged;
    public event Action<int> OnGoldChanged;
    public event Action<float> OnSpeedChanged;

    private int _maxHealth;
    private int _health;
    private int _healthRegeneration;
    private int _maxStamina;
    private int _stamina;
    private int _staminaRegeneration;
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

    public int HealthRegeneration
    {
        get => _healthRegeneration;
        set
        {
            if(_healthRegeneration != value)
            {
                _healthRegeneration = value;
                OnHealthRegenerationChanged?.Invoke(_healthRegeneration);
            }
        }
    }

    public int MaxStamina
    {
        get => _maxStamina;
        set
        {
            if(_maxStamina != value)
            {
                _maxStamina = value;
                OnMaxStaminaChanged?.Invoke(_maxStamina);
            }
        }
    }

    public int Stamina
    {
        get => _stamina;
        set
        {
            if(_stamina != value)
            {
                _stamina = value;
                OnStaminaChanged?.Invoke(_stamina);
            }
        }
    }

    public int StaminaRegeneration
    {
        get => _staminaRegeneration;
        set
        {
            if(_staminaRegeneration != value)
            {
                _staminaRegeneration = value;
                OnStaminaRegenerationChanged?.Invoke(_staminaRegeneration);
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

    public float Range { get; set; }

    public float AttackCooldown { get; set; }

    public float DashSpeed { get; set; } 
    public float DashDuration { get; set; } 
    public float DashCooldown { get; set; }
    public int DashCost { get; set; }
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
        Health = Mathf.Max(0, Health - damage);
    }

    public PlayerModel
    (
        int maxHealth,
        int healthRegeneration,

        int maxStamina,
        int staminaRegeneration,
        float speed,

        float range,
        float attackCooldown,
        
        float dashSpeed, 
        float dashDuration, 
        float dashCooldown,
        int dashCost,

        int gold
    )
    {
        MaxHealth = maxHealth;
        Health = maxHealth;
        HealthRegeneration = healthRegeneration;

        MaxStamina = maxStamina;
        Stamina = maxStamina;
        StaminaRegeneration = staminaRegeneration;
        Speed = speed;
        Range = range;

        AttackCooldown = attackCooldown;

        DashSpeed = dashSpeed;
        DashDuration = dashDuration;
        DashCooldown = dashCooldown;
        DashCost = dashCost;
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

    public void RegenerateHealth()
    {
        Health = Mathf.Min(MaxHealth, Health + HealthRegeneration);
    }

    public void RegenerateStamina()
    {
        int regenAmount = Mathf.RoundToInt(StaminaRegeneration * STAMINA_REGEN_INTERVAL);
        Stamina = Mathf.Min(MaxStamina, Stamina + regenAmount);
    }
}