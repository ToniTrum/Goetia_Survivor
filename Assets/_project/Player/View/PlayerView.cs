using System;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class PlayerView : IEntityView<PlayerStateType>
{
    [Inject] private PlayerFsm _fsm;

    public void UpdateParameterBar(int damage, ProgressBar healthBar, int maxHealth)
    {
        healthBar.value = Math.Clamp(healthBar.value - damage, 0, maxHealth);
    }

    public void PlayHit()
    {
        
    }

    public void PlayDeath()
    {
    }

    public PlayerStateType GetState()
    {
        return _fsm.CurrentState;
    }

    public void ChangeState(PlayerStateType newState, Animator animator)
    {
        _fsm.ChangeState(newState, animator);
    }
}