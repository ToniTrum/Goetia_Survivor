using System;
using UnityEngine;

public abstract class EntityFsm<T>
    where T : Enum
{
    protected T _currentState;
    private readonly string _animatorParameter = "AnimationState";

    public void ChangeState(T state, Animator animator)
    {
        _currentState = state;
        animator.SetInteger(_animatorParameter, Convert.ToInt32(_currentState));
    }
}
