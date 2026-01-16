using UnityEngine;

[CreateAssetMenu(menuName = "Config/Hand")]
public class HandConfig : ScriptableObject
{
    public float BaseRange;
    public float BaseAttackCooldown;
    public float BaseDamage;
}
