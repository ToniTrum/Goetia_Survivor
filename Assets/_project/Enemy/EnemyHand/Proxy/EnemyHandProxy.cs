using UnityEngine;

public class EnemyHandProxy : MonoBehaviour
{
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponentInParent<Enemy>();
    }

    public void OnAttackAnimationComplete()
    {
        StartCoroutine(_enemy.OnAttackAnimationComplete());
    }
}
