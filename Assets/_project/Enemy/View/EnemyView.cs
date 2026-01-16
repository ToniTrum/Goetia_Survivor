using System;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class EnemyView : IEntityView<EnemyStateType>
{
    [Inject] private EnemyFsm _fsm;

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

    public void ChangeState(EnemyStateType state, Animator animator)
    {
        _fsm.ChangeState(state, animator);
    }
}
