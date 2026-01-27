using UnityEngine;

[CreateAssetMenu(menuName = "Config/Projectile")]
public class ProjectileConfig : ScriptableObject
{
    public float BaseSpeed;
    public int BaseDamage;
    public GameObject Prefab;
}