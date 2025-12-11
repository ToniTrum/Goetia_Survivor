using System;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyView : IEntityView<EnemyStateType>
{
    private EnemyModel _model;

    public void UpdateParameterBar(int damage, ProgressBar healthBar)
    {
        healthBar.value = Math.Clamp(healthBar.value - damage, 0, _model.MaxHealth);
    }

    public void PlayHit()
    {
        
    }

    public void PlayDeath()
    {
        
    }

    public void ChangeState(EnemyStateType state, Animator animator)
    {
        
    }
}
