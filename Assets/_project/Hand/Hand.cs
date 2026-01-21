using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Hand<TState> : MonoBehaviour
    where TState : Enum
{
    private Animator _animator;
    protected Collider2D Collider2D;

    [Inject] protected HandView<TState> View { get; private set; }
    [Inject] protected HandPresenter Presenter { get; private set; }
    [Inject] protected HandTargetLocator TargetLocator { get; private set; }

    public void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        Collider2D = GetComponentInChildren<Collider2D>();
    }

    public TState GetState()
    {
        return View.GetState();
    }

    public void ChangeState(TState state)
    {
        View.ChangeState(state, _animator);
    }

    public Vector3? GetDirection()
    {
        var targets = Presenter.GetTargets();
        if (targets == null)
        {
            return null;
        }

        return TargetLocator.ChooseTarget(targets, transform.position).position;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        var targets = Presenter.GetTargets();

        if (targets == null)
        {
            return;
        }

        Gizmos.DrawLine
        (
            transform.position, 
            TargetLocator.ChooseTarget(targets, transform.position).position
        );
    }
}
