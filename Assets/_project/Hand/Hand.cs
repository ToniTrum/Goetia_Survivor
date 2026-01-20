using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Hand<TState> : MonoBehaviour
    where TState : Enum
{
    private Animator _animator;

    [Inject] protected HandView<TState> View { get; private set; }
    [Inject] protected HandPresenter Presenter { get; private set; }
    [Inject] protected HandTargetLocator TargetLocator { get; private set; }

    public void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void ChangeState(TState state)
    {
        View.ChangeState(state, _animator);
    }

    public Vector3 GetDirection()
    {
        return TargetLocator.ChooseTarget(Presenter.GetTargets(), transform.position).position;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine
        (
            transform.position, 
            TargetLocator.ChooseTarget(Presenter.GetTargets(), transform.position).position
        );
    }
}
