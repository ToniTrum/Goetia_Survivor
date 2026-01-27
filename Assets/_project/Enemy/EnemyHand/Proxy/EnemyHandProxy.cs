using UnityEngine;
using Zenject;

public class EnemyHandProxy : MonoBehaviour
{
    private Enemy _enemy;
    
    [Inject] private ProjectileFactory _projectileFactory;
    [SerializeField] private ProjectileConfig _projectileConfig;

    private void Awake()
    {
        _enemy = GetComponentInParent<Enemy>();
    }

    public void OnAttackAnimationComplete()
    {
        StartCoroutine(_enemy.OnAttackAnimationComplete());
    }

    public void OnStrike()
    {
        _projectileFactory.Create(_projectileConfig, transform.position, transform.rotation);
    }
}
