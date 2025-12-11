using System;
using UnityEngine;

public abstract class EntityFsm<T>
    where T : Enum
{
    private T _currentState;
    private string _animatorParameter = "AnimationState";

    public void ChangeState(T state, Animator animator)
    {
        _currentState = state;
        animator.SetInteger(_animatorParameter, Convert.ToInt32(_currentState));
    }
}
