using System;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public abstract class Entity<TState> : MonoBehaviour, IEntity
    where TState : Enum
{
    protected Rigidbody2D _rigidbody;
    protected Animator _animator;
    // protected Hand _hand;

    protected ProgressBar _healthBar;
    [Inject] protected IEntityView<TState> View { get; private set; }
    [Inject] protected IEntityPresenter Presenter { get; private set; }
    
    public bool IsRightSight { get; private set;}

    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        //_hand = GetComponentInChildren<Hand>();
    }

    public void TakeDamage(int damage)
    {
        View.UpdateParameterBar(damage, _healthBar, Presenter.GetMaxHealth());
        View.PlayHit();
        
        Presenter.TakeDamage(damage);
    }

    public void DealDamage(IEntity target, int damage)
    {
        Presenter.DealDamage(target, damage);
    }

    public void PlayDeath()
    {
        View.PlayDeath();
    }
}
