using System.Collections;
using UnityEngine;
using Zenject;

public class Enemy : Entity<EnemyStateType>
{
    [Inject] protected EnemyMovement Movement;
    [Inject] protected EnemyService EnemyService;

    private bool _isAttackCooldown = false;

    public void OnSpawnAnimationComplete()
    {
        EnemyService.Register(this);
        View.ChangeState(EnemyStateType.Idle, Animator);
        Hand.ChangeState(EnemyStateType.Idle);
    }

    public IEnumerator OnAttackAnimationComplete()
    {
        Debug.Log("OnAttackAnimationComplete");
        _isAttackCooldown = true;
        Idle();

        yield return new WaitForSeconds(Presenter.GetAttackCooldown());
        Debug.Log("Attack cooldown over");
        _isAttackCooldown = false;
    }

    private void OnDisable()
    {
        EnemyService.Unregister(this);
    }

    public void Idle()
    {
        View.ChangeState(EnemyStateType.Idle, Animator);
        Hand.ChangeState(EnemyStateType.Idle);
    }

    private bool Move(Vector3 targetPosition)
    {
        Movement.Move(targetPosition, transform, Presenter.GetRange(), Presenter.GetSpeed());
        if (Movement.IsMoving)
        {
            View.ChangeState(EnemyStateType.Walk, Animator);
            Hand.ChangeState(EnemyStateType.Walk);
            
            return true;
        }

        return false;
    }

    public void Attack()
    {
        View.ChangeState(EnemyStateType.Attack, Animator);
        Hand.ChangeState(EnemyStateType.Attack);
    }

    private void Update()
    {
        EnemyStateType state = View.GetState();
        var direction = Hand.GetDirection();

        if (state != EnemyStateType.Spawn && state != EnemyStateType.Death)
        {
            if (direction == null || _isAttackCooldown)
            {
                Idle();
            }
            else
            {
                bool isMoving = Move(direction.Value);

                if (!isMoving && !_isAttackCooldown)
                {
                    Debug.Log("Attack");
                    Attack();
                }
            }
        }
    }
}
