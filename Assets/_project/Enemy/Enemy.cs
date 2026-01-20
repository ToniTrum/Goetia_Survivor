using UnityEngine;
using Zenject;

public class Enemy : Entity<EnemyStateType>
{
    [Inject] protected EnemyMovement Movement;
    [Inject] protected EnemyService EnemyService;

    public void OnSpawnAnimationComplete()
    {
        EnemyService.Register(this);
        View.ChangeState(EnemyStateType.Idle, Animator);
        Hand.ChangeState(EnemyStateType.Idle);
    }

    private void OnDisable()
    {
        EnemyService.Unregister(this);
    }

    private void Move()
    {
        Vector3 target = Hand.GetDirection();
        Movement.Move(target, transform, Presenter.GetRange(), Presenter.GetSpeed());
        if (Movement.IsMoving)
        {
            View.ChangeState(EnemyStateType.Walk, Animator);
            Hand.ChangeState(EnemyStateType.Walk);
        }
    }

    private void Update()
    {
        EnemyStateType state = View.GetState();
        if (state != EnemyStateType.Spawn && state != EnemyStateType.Death)
        {
            Move();
        }
    }
}
