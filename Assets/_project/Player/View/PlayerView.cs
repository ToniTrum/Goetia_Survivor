using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PlayerView : IEntityView<PlayerStateType>
{
    [Inject] private PlayerFsm _fsm;

    public void UpdateParameterBar(Image parameterBar, int damage, int maxHealth)
    {
        float amount = parameterBar.fillAmount * maxHealth;
        parameterBar.fillAmount = Math.Clamp(amount - damage, 0, maxHealth) / maxHealth;
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