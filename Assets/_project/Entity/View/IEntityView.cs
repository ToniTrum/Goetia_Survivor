using UnityEngine;
using UnityEngine.UIElements;

public interface IEntityView
{
    public void UpdateParameterBar(int currentValue, ProgressBar parameterBar);
    public void PlayHit();
    public void PlayDeath();
}
