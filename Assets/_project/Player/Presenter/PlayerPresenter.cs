using ModestTree;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Video;
using Zenject;

public class PlayerPresenter
{
    private PlayerView _view;
    private PlayerModel _model;
    private PlayerFsm _fsm;

    [Inject]
    private void Init(PlayerView view, PlayerModel model, PlayerFsm fsm)
    {
        _view = view;
        _model = model;
        _fsm = fsm;
    }

    public int GetAnimationState()
    {
        return (int)_fsm.playerState;
    }

    public void SetAnimationState(PlayerStateType state)
    {
        _fsm.ChangeState(state);
    }

    public void Move(Vector2 move)
    {
        if ((move.x > 0f && _view.isRightSight) || (move.x < 0f && !_view.isRightSight))
        {
            _view.Flip();
        }
        Vector2 vel = move.normalized * (_model.GetSpeed() * Time.deltaTime);
        _view.ApplyVelocity(vel);
    }

    public void DealDamage()
    {
        //TODO: Make examination with enemies
    }

    public void TakeDamage(int damage)
    {
        _model.SetHealth(_model.GetHealth()-damage);
    }
    
}