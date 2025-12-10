using UnityEngine;

public class PlayerWalkState : IPlayerState
{
    private PLayerStateType _stateType = PLayerStateType.Walk;

    public override void Enter()
    {
        Debug.Log("Entered PlayerWalkState");
    }

    public override void Update()
    {
        
    }

    public override void Exit()
    {
        Debug.Log("Exited PlayerWalkState");
    }
}