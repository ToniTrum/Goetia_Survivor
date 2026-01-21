using UnityEngine;

[CreateAssetMenu(menuName = "Config/Enemy")]
public class EnemyConfig : ScriptableObject
{
    public float BaseSpeed;
    public int BaseMaxHealth;
    public float BaseRange;
    public float BaseAttackCooldown;
}
