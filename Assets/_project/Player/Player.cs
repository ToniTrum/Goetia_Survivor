using System;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    private PlayerPresenter _presenter;
    private PlayerView _playerView;
    private Vector2 _moveInput;
    private Rigidbody2D _rb;

    [Inject]
    public void Init(PlayerPresenter presenter, PlayerView playerView)
    {
        _presenter = presenter;
        _playerView = playerView;
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _moveInput.Normalize();
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _moveInput * Time.fixedDeltaTime);
    }

    public void TakeDamage(int damage)
    {
        _presenter.TakeDamage(damage);
    }
    
}
