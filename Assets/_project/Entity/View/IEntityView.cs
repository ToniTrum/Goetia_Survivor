using System;
using UnityEngine;
using UnityEngine.UI;

public interface IEntityView<T>
    where T : Enum
{
    public void UpdateParameterBar(Image parameterBar, int currentValue, int maxValue);
    public void PlayHit();
    public void PlayDeath();
    public T GetState();
    public void ChangeState(T newState, Animator animator);
}
