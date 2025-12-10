using UnityEngine;

public class PlayerDashState : IPlayerState
{
    private PLayerStateType _stateType = PLayerStateType.Dash;

    public override void Enter()
    {
        Debug.Log("Entered PlayerDashState");
    }
    
    public override void Exit()
    {
        Debug.Log("Exited PlayerDashState");
    }
}