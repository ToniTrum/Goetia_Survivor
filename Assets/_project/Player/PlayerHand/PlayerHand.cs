using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : Hand<PlayerStateType>
{
    [SerializeField] LayerMask enemyLayer;

    private void Update()
    {
        LookAtNearestEnemy();
    }

    public void LookAtNearestEnemy()
    {
        if (Presenter == null || TargetLocator == null)
            return;
        
        var targets = Presenter.GetTargets();
        if (targets == null || targets.Count == 0)
            return;
        
        var nearestTarget = TargetLocator.ChooseTarget(targets, transform.position);
        if (nearestTarget == null)
            return;
        
        var dir = TargetLocator.TargetDirection(nearestTarget, transform.position);
        if (dir.sqrMagnitude < 0.0001f)
            return;
        
        bool lookRight = dir.x >= 0f;
        float parentScaleX = transform.parent ? transform.parent.localScale.x : 1f;
        Vector3 localScale = transform.localScale;
        localScale.x = lookRight ? 1f : -1f;
        if (parentScaleX < 0)
            localScale.x *= -1f;
        transform.localScale = localScale;
        
        float angle = Mathf.Atan2(dir.y, Mathf.Abs(dir.x)) * Mathf.Rad2Deg; 
        transform.localRotation = Quaternion.Euler(0f, 0f, angle);
    }

    public bool IsNearFromEnemy()
    {
        var targets = Presenter.GetTargets();
        if (targets == null || targets.Count == 0) 
            return false;
        
        var nearest = TargetLocator.ChooseTarget(targets, transform.position);
        if (nearest == null) 
            return false;
        
        float distance = Vector2.Distance(transform.position, nearest.position);
        float range = Presenter != null ? Presenter.GetRange() : Presenter.GetRange();
        return distance <= range;
    }

    public void DealDamageToEnemies()
    {
        if (Collider2D == null)
        {
            return;
        }

        Vector2 center = Collider2D.bounds.center;
        Vector2 size = Collider2D.bounds.size;
        
        ContactFilter2D filter = new ContactFilter2D();
        filter.useTriggers = true;
        filter.useLayerMask = true;
        filter.layerMask = enemyLayer;
        
        List<Collider2D> results = new List<Collider2D>();
        int count = Physics2D.OverlapBox(center, size * 1.5f, transform.rotation.eulerAngles.z, filter, results);
        
        Debug.Log($"ContactFilter found {count} enemies");
        
        foreach (var enemyCollider in results)
        {
            float distance = Vector2.Distance(transform.position, enemyCollider.transform.position);
            float range = Presenter != null ? Presenter.GetRange() : Presenter.GetRange();
            
            if (distance <= range)
            {
                OnAttack();
                
                var enemy = enemyCollider.GetComponent<IEntity>();
                if (enemy != null)
                {
                    int damage = Presenter != null ? Presenter.GetDamage() : 10;
                    enemy.TakeDamage(damage);
                }
            }
        }
    }

    public void PerformAttack()
    {
        ChangeState(PlayerStateType.Attack);
    }
}