using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public abstract class Entity<TState> : MonoBehaviour, IEntity
    where TState : Enum
{
    protected Rigidbody2D Rigidbody { get; private set; }
    protected Animator Animator { get; private set; }
    protected Hand<TState> Hand { get; private set; }
    protected Image HealthBar;
    
    [Inject] protected IEntityView<TState> View { get; private set; }
    [Inject] protected IEntityPresenter Presenter { get; private set; }
    
    protected bool IsRightSight { get; set;}

    public void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        Hand = GetComponentInChildren<Hand<TState>>();
    }

    public void TakeDamage(int damage)
    {
        View.UpdateParameterBar(HealthBar, damage, Presenter.GetMaxHealth());
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
