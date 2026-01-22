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

    public Vector3 Flip(Vector3 direction, Vector3 localScale)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (angle > 90 || angle < -90)
        {
            localScale.x = -1f;
        }
        else
        {
            localScale.x = 1f;
        }

        return localScale;
    }
}