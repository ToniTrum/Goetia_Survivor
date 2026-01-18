using UnityEngine;
using Zenject;

public class Enemy : Entity<EnemyStateType>
{
    private EnemyService _enemyService;

    [Inject]
    private void Construct(EnemyService enemyService)
    {
        _enemyService = enemyService;
    }

    public void OnSpawnAnimationComplete()
    {
        _enemyService.Register(this);
        View.ChangeState(EnemyStateType.Idle, Animator);
        Hand.ChangeState(EnemyStateType.Idle);
    }

    private void OnDisable()
    {
        _enemyService.Unregister(this);
    }
}
