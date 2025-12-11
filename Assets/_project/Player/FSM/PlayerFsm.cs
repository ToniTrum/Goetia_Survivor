using UnityEngine;

public class PlayerFsm
{
    public PlayerStateType playerState { get;  private set; }

    public PlayerFsm(PlayerStateType playerState)
    {
        this.playerState = playerState;
    }

    public PlayerFsm()
    {
        playerState = PlayerStateType.PlayerIdle;
    }
    
    public void ChangeState(PlayerStateType newState)
    {
        playerState = newState;
    }
}
