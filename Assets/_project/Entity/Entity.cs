using System;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public abstract class Entity<TState> : MonoBehaviour, IEntity
    where TState : Enum
{
    protected Rigidbody2D Rigidbody { get; private set; }
    protected Animator Animator { get; private set; }
    protected ProgressBar HealthBar { get; private set; }
    protected Hand<TState> Hand { get; private set; }
    
    [Inject] protected IEntityView<TState> View { get; private set; }
    [Inject] protected IEntityPresenter Presenter { get; private set; }
    
    public bool IsRightSight { get; private set;}

    public void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        Hand = GetComponentInChildren<Hand<TState>>();
    }

    public void TakeDamage(int damage)
    {
        View.UpdateParameterBar(damage, HealthBar, Presenter.GetMaxHealth());
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
