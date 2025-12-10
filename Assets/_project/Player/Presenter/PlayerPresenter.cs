using ModestTree;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Video;
using Zenject;

public class PlayerPresenter
{
    private IPlayerView _view;
    private PlayerModel _model;
    private PLayerFsm _fsm;

    [Inject]
    private void Init(IPlayerView view, PlayerModel model,  PLayerFsm fsm)
    {
        _view = view;
        _model = model;
        _fsm = fsm;
    }

    public void Move(Vector2 move)
    {
        _fsm.ChangeState(new PlayerWalkState());
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