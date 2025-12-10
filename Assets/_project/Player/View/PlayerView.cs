using System;
using ModestTree;
using UnityEngine;
using Zenject;

public class PlayerView : MonoBehaviour
{
    private PlayerPresenter _presenter;
    private Rigidbody2D _rigidbody;
    private Vector2 _vector2;
    private Animator _animator;
    public bool isRightSight { get; private set;}

    [Inject]
    private void Init(PlayerPresenter presenter)
    {
        _presenter = presenter;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        
    }

    private void Update()
    {
        StatusCheck();
    }

    private void Move()
    {
        _presenter.SetAnimationState(PlayerStateType.PlayerWalk);
        _animator.SetInteger("AnimationState", _presenter.GetAnimationState());
        _vector2.Normalize();
        _presenter.Move(_vector2);
    }

    private void Idle()
    {
        _presenter.SetAnimationState(PlayerStateType.PlayerIdle);
        _animator.SetInteger("AnimationState", _presenter.GetAnimationState());
    }

    public void Flip()
    {
        isRightSight = !isRightSight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    private void StatusCheck()
    {
        _vector2.x = Input.GetAxisRaw("Horizontal");
        _vector2.y = Input.GetAxisRaw("Vertical");
        if (_vector2 is { x: 0, y: 0 })
        {
            Idle();
        }
        else
        {
            Move();
        }
    }
    
    public void ApplyVelocity(Vector2 velocity)
    {
        _rigidbody.MovePosition(_rigidbody.position + velocity);
    }
}