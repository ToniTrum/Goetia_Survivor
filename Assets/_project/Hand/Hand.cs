using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(SpriteRenderer))]
public class Hand<TState> : MonoBehaviour
    where TState : Enum
{
    private SpriteRenderer _spriteRenderer;

    [Inject] protected HandView<TState> View { get; private set; }
    [Inject] protected HandPresenter Presenter { get; private set; }
    [Inject] protected HandTargetLocator TargetLocator { get; private set; }

    public void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Enable()
    {
        View.EnableSprite(_spriteRenderer);
    }

    public void Disable()
    {
        View.DisableSprite(_spriteRenderer);
    }

    public void FixedUpdate()
    {
        IReadOnlyList<Transform> targets = Presenter.GetTargets();
        Transform target = TargetLocator.ChooseTarget(targets, transform.position);
    }

    // public void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawLine(transform.position, TargetLocator.ChooseTarget(Presenter.GetTargets(), transform.position).position);
    // }
}
