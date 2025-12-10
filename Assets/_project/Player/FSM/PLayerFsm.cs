using System.Runtime.CompilerServices;
using UnityEngine;
using Zenject;

public class PLayerFsm
{
    private PlayerModel _model;
    private IPlayerState _state;

    [Inject]
    private void Init(PlayerModel model)
    {
        _model = model;
    } 
    
    public void ChangeState(IPlayerState newState)
    {
        if (_state != null) _state.Exit();
        
        _state = newState;
        _model.SetState(newState._stateType);
        _state.Enter();
        
    }
}