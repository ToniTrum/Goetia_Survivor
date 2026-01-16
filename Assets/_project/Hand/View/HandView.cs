using System;
using UnityEngine;
using Zenject;

public abstract class HandView<T>
    where T : Enum
{
    [Inject] private HandFsm<T> _fsm;

    public abstract void Idle();
    public abstract void Walk();
    public abstract void Attack();

    public void EnableSprite(SpriteRenderer spriteRenderer)
    {
        spriteRenderer.enabled = true;
    }

    public void DisableSprite(SpriteRenderer spriteRenderer)
    {
        spriteRenderer.enabled = false;
    }

    public void ChangeState(T state, Animator animator)
    {
        _fsm.ChangeState(state, animator);
    }
}