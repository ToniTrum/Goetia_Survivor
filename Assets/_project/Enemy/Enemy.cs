using UnityEngine;
using Zenject;

public class Enemy : Entity<EnemyStateType>
{
    public class Factory : PlaceholderFactory<Vector3, GameObject, Enemy> { }

    private EnemyService _enemyService;

    [Inject]
    private void Construct(EnemyService enemyService)
    {
        _enemyService = enemyService;
    }

    public void OnSpawnAnimationComplete()
    {
        _enemyService.Register(this);        
        View?.ChangeState(EnemyStateType.Idle, Animator);
    }

    private void OnDisable()
    {
        _enemyService.Unregister(this);
    }
}
