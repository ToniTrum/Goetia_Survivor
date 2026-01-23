using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class EnemyView : IEntityView<EnemyStateType>
{
    [Inject] private EnemyFsm _fsm;

    public Quaternion Flip(Vector3 direction)
    {
        Quaternion rotation = Quaternion.identity;

        if (direction.x < 0)
        {
            rotation = Quaternion.Euler(0, -180, 0);
        }
        else if (direction.x > 0)
        {
            rotation = Quaternion.Euler(0, 0, 0);
        }

        return rotation;
    }

    public void UpdateParameterBar(Image healthBar, int damage, int maxHealth)
    {
        float amount = healthBar.fillAmount * maxHealth;
        healthBar.fillAmount = Math.Clamp(amount - damage, 0, maxHealth) / maxHealth;
    }

    public void PlayHit()
    {
        
    }

    public void PlayDeath()
    {
        
    }

    public EnemyStateType GetState()
    {
        return _fsm.CurrentState;
    }

    public void ChangeState(EnemyStateType state, Animator animator)
    {
        _fsm.ChangeState(state, animator);
    }
}
