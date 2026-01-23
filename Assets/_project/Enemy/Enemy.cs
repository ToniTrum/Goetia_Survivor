using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Enemy : Entity<EnemyStateType>
{
    private bool _isAttackCooldown = false;

    [Inject] protected EnemyMovement Movement;
    [Inject] protected EnemyService EnemyService;

    public void OnSpawnAnimationComplete()
    {
        transform.Find("HealthBar").gameObject.SetActive(true);
        HealthBar = transform.Find("HealthBar/Background/ProgressBar").GetComponent<Image>();

        EnemyService.Register(this);
        Idle();
    }

    public IEnumerator OnAttackAnimationComplete()
    {
        _isAttackCooldown = true;
        Idle();

        yield return new WaitForSeconds(Presenter.GetAttackCooldown());
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
        if (View.GetState() == EnemyStateType.Attack)
        {
            return false;
        }

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

    public void OnFlip(Vector3 direction)
    {
        if (View is EnemyView view)
        {
            transform.rotation = view.Flip(direction);
        }
    }

    private void Update()
    {
        EnemyStateType state = View.GetState();
        var direction = Hand.GetDirection().Value;
        if (direction == null)
        {
            Idle();
            return;
        }

        if (state != EnemyStateType.Spawn && state != EnemyStateType.Death)
        {
            OnFlip(direction.normalized);

            if (_isAttackCooldown)
            {
                Idle();
            }
            else
            {
                bool isMoving = Move(direction);

                if (!isMoving && !_isAttackCooldown)
                {
                    Attack();
                }
            }
        }
    }
}
