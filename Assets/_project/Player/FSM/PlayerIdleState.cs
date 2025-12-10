using UnityEngine;

public class PlayerIdleState : IPlayerState
{
    
    private PLayerStateType _stateType = PLayerStateType.Idle;

    public override void Enter()
    {
        Debug.Log("Entered PlayerIdleState");
    }

    public override void Exit()
    {
        Debug.Log("Exited PlayerIdleState");
    }
}