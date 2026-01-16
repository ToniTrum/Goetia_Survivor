using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Hand : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private readonly HandView _view;
    private readonly HandPresenter _presenter;
    private readonly HandTargetLocator _targetLocator;

    public void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Enable()
    {
        _view.EnableSprite(_spriteRenderer);
    }

    public void Disable()
    {
        _view.DisableSprite(_spriteRenderer);
    }

    public void FixedUpdate()
    {
        IReadOnlyList<Transform> targets = _presenter.GetTargets();
        Transform target = _targetLocator.ChooseTarget(targets, transform.position);
        Debug.Log(target);
    }
}
