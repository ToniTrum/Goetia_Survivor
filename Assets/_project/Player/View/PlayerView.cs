using System;
using ModestTree;
using UnityEngine;
using Zenject;

public class PlayerView : MonoBehaviour, IPlayerView
{
    private PlayerPresenter _presenter;
    private PLayerFsm _fsm;
    private Rigidbody2D _rigidbody;
    private Vector2 _vector2;

    [Inject]
    private void Init(PlayerPresenter presenter , PLayerFsm fsm)
    {
        _presenter = presenter;
        _fsm = fsm;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_rigidbody.linearVelocity.magnitude > 0.1f)
        {
            _fsm.ChangeState(new PlayerIdleState());
        }
        else
        {
            _vector2.x = Input.GetAxisRaw("Horizontal");
            _vector2.y = Input.GetAxisRaw("Vertical");
            _vector2.Normalize();
            _presenter.Move(_vector2);
        }
        
    }
    
    public void ApplyVelocity(Vector2 velocity)
    {
        _rigidbody.MovePosition(_rigidbody.position + velocity);
    }
}