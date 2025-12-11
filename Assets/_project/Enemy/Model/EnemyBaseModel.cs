using UnityEngine;

[CreateAssetMenu(menuName = "BaseModels/Enemy")]
public class EnemyBaseModel : ScriptableObject
{
    public float BaseSpeed;
    public int BaseMaxHealth;
    public int BaseDamage;
    public float BaseAttackRange;
}
