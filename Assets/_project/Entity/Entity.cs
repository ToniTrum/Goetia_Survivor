using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public abstract class Entity : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private ProgressBar _healthBar;
    private IEntityView _view;
    private IEntityPresenter _presenter;
    public bool IsRightSight { get; private set;}

    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        _view.UpdateParameterBar(damage, _healthBar);
        _view.PlayHit();
        
        _presenter.TakeDamage(damage);
    }

    public void DealDamage()
    {
        _presenter.DealDamage();
    }

    public void PlayDeath()
    {
        _view.PlayDeath();
    }
}
