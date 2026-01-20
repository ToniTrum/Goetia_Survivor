using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Scriptable Objects/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    public int MaxHealth = 100;
    public float Speed = 5f;
    public float Range = 2f;

    public float AttackCooldown = 1f;

    public float DashSpeed = 10f;
    public float DashDuration = 0.3f;
    public float DashCooldown = 1.5f;
}
