using System;
using UnityEngine;
using UnityEngine.UIElements;

public interface IEntityView<T>
    where T : Enum
{
    public void UpdateParameterBar(int currentValue, ProgressBar parameterBar);
    public void PlayHit();
    public void PlayDeath();
    public void ChangeState(T newState, Animator animator);
}
