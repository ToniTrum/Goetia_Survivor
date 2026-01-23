using System;
using UnityEngine;
using Zenject;

public abstract class HandView<T>
    where T : Enum
{
    [Inject] private HandFsm<T> _fsm;

    public T GetState()
    {
        return _fsm.CurrentState;
    }

    public void ChangeState(T state, Animator animator)
    {
        _fsm.ChangeState(state, animator);
    }
}